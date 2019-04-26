using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32.SafeHandles;


namespace Disposable
{
    class MyDisposable : IDisposable
    {
        MySafeFileHandle handle = 
            NativeMethods.CreateFile("somefile", NativeMethods.GENERIC_READ, 
                FileShare.Read, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);        
        int x = 5;
        public void PrintX() => Console.Write(x);

        public void Dispose()
        {
            handle.Dispose();
        }
    }
    internal class MySafeFileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        // Create a SafeHandle, informing the base class
        // that this SafeHandle instance "owns" the handle,
        // and therefore SafeHandle should call
        // our ReleaseHandle method when the SafeHandle
        // is no longer in use.
        private MySafeFileHandle()
            : base(true)
        {
        }
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        override protected bool ReleaseHandle()
        {
            // Here, we must obey all rules for constrained execution regions.
            return NativeMethods.CloseHandle(handle);
            // If ReleaseHandle failed, it can be reported via the
            // "releaseHandleFailed" managed debugging assistant (MDA).  This
            // MDA is disabled by default, but can be enabled in a debugger
            // or during testing to diagnose handle corruption problems.
            // We do not throw an exception because most code could not recover
            // from the problem.
        }
    }
    internal static class NativeMethods
    {
        // Win32 constants for accessing files.
        internal const int GENERIC_READ = unchecked((int)0x80000000);

        // Allocate a file object in the kernel, then return a handle to it.
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        internal extern static MySafeFileHandle CreateFile(String fileName,
           int dwDesiredAccess, System.IO.FileShare dwShareMode,
           IntPtr securityAttrs_MustBeZero, System.IO.FileMode dwCreationDisposition,
           int dwFlagsAndAttributes, IntPtr hTemplateFile_MustBeZero);

        // Use the file handle.
        [DllImport("kernel32", SetLastError = true)]
        internal extern static int ReadFile(MySafeFileHandle handle, byte[] bytes,
           int numBytesToRead, out int numBytesRead, IntPtr overlapped_MustBeZero);

        // Free the kernel's file object (close the file).
        [DllImport("kernel32", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal extern static bool CloseHandle(IntPtr handle);
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDisposable disposable;
            using (disposable = new MyDisposable())
            {

            }
            disposable.PrintX();
        }
    }
}
