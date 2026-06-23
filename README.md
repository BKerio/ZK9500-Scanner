### Step 1 - Install hardware drivers

1. Connect the **ZK9500** via USB to the enrollment PC (Windows).
2. Get the driver from **Setup**
3. Download and install the **ZKTeco USB fingerprint driver** for your device from [ZKTeco](https://www.zkteco.com/) (or the driver CD / vendor package that ships with the scanner).
4. Open **Device Manager** → confirm the device appears under **Biometric devices** or **USB devices** without a warning icon.
5. If Windows installs a generic driver, replace it with ZKTeco’s **ZKFinger** / **ZK9500** driver when prompted.

### Step 2 - Verify SDK libraries

The project includes the ZKFinger C# wrapper in:

```text
ZK9500/lib/
├── libzkfpcsharp.dll   # .NET binding
└── libzkfp.dll         # Native driver (copied to build output)  ''''''
```

If capture fails after driver install, copy the matching `libzkfp.dll` and `libzkfpcsharp.dll` from your ZKTeco **ZKFinger SDK** package (must match scanner firmware / SDK version).

### Step 3 - Install .NET 8 SDK

```bash
dotnet --version   # should be 8.x
```

Download: https://dotnet.microsoft.com/download/dotnet/8.0

### Step 4 - Build and run the scanner service

```bash
cd ZK9500
dotnet build
dotnet run
```

Expected output:

```text
SmartPOS Fingerprint Scanner Service
Listening on http://127.0.0.1:17890
Endpoints: GET /health  POST /capture  POST /check-duplicate
Scanner ready (1 device(s) detected)
```
