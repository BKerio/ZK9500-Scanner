using System;
using System.Threading;
using libzkfpcsharp;

class Program
{
    static void Main()
    {
        Console.WriteLine("Initializing...");

        int ret = zkfp2.Init();
        if (ret != zkfperrdef.ZKFP_ERR_OK)
        {
            Console.WriteLine("Init failed");
            return;
        }

        int count = zkfp2.GetDeviceCount();
        Console.WriteLine($"Devices: {count}");

        if (count <= 0)
        {
            Console.WriteLine("No device found");
            zkfp2.Terminate();
            return;
        }

        IntPtr dev = zkfp2.OpenDevice(0);

        if (dev == IntPtr.Zero)
        {
            Console.WriteLine("Failed to open device");
            zkfp2.Terminate();
            return;
        }

        Console.WriteLine("Place finger on scanner...");

        byte[] fpImage = new byte[1024 * 1024];
        byte[] fpTemplate = new byte[2048];
        int size = 0;

        while (true)
        {
            int result = zkfp2.AcquireFingerprint(dev, fpImage, fpTemplate, ref size);

            if (result == zkfperrdef.ZKFP_ERR_OK)
            {
                Console.WriteLine($"Fingerprint captured! Size: {size}");
                break;
            }

            Thread.Sleep(100);
        }

        zkfp2.CloseDevice(dev);
        zkfp2.Terminate();

        Console.WriteLine("Done");
        Console.ReadLine();
    }
}