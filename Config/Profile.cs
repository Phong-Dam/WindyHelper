using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

public static class Profile
{
    private static string WindyHelperConfig;

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder retVal, int size, string filePath);

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern bool WritePrivateProfileString(string section, string key, string value, string filePath);

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern int GetPrivateProfileInt(string section, string key, int defaultValue, string filePath);

    public static void ProfileSetInt(string section, string key, int value)
    {
        WritePrivateProfileString(section, key, value.ToString(), WindyHelperConfig);
    }

    public static int ProfileGetInt(string section, string key, int defaultValue)
    {
        return GetPrivateProfileInt(section, key, defaultValue, WindyHelperConfig);
    }

    public static int ProfileFetchInt(string section, string key, int defaultValue)
    {
        int result = ProfileGetInt(section, key, -17236);
        if (result == -17236)
        {
            result = defaultValue;
            ProfileSetInt(section, key, result);
        }
        return result;
    }

    public static void ProfileSetFloat(string section, string key, float value)
    {
        WritePrivateProfileString(section, key, value.ToString("F4"), WindyHelperConfig);
    }

    public static float ProfileGetFloat(string section, string key, float defaultValue)
    {
        StringBuilder returnValue = new StringBuilder(20);
        GetPrivateProfileString(section, key, defaultValue.ToString("F4"), returnValue, 20, WindyHelperConfig);
        return float.Parse(returnValue.ToString());
    }

    public static float ProfileFetchFloat(string section, string key, float defaultValue)
    {
        float result = ProfileGetFloat(section, key, -28356.0f);
        if (result == -28356.0f)
        {
            result = defaultValue;
            ProfileSetFloat(section, key, result);
        }
        return result;
    }

    private static StringBuilder ProfileStringTmp = new StringBuilder(256);

    public static string ProfileGetString(string section, string key, string defaultValue)
    {
        GetPrivateProfileString(section, key, defaultValue, ProfileStringTmp, 256, WindyHelperConfig);
        return ProfileStringTmp.ToString();
    }

    public static void ProfileSetString(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, WindyHelperConfig);
    }

    public static string ProfileFetchString(string section, string key, string defaultValue)
    {
        string result = ProfileGetString(section, key, "iNvALidStrInG");
        if (result == "iNvALidStrInG")
        {
            ProfileSetString(section, key, defaultValue);
            return ProfileGetString(section, key, defaultValue);
        }
        return result;
    }

    public static void ProfileInit(string fileName)
    {
        string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        WindyHelperConfig = Path.Combine(exeDirectory, fileName);
    }

    public static void ProfileSetBool(string section, string key, bool value)
    {
        ProfileSetInt(section, key, value ? 1 : 0);
    }

    public static bool ProfileGetBool(string section, string key, bool defaultValue)
    {
        return ProfileGetInt(section, key, defaultValue ? 1 : 0) > 0;
    }

    public static bool ProfileFetchBool(string section, string key, bool defaultValue)
    {
        return ProfileFetchInt(section, key, defaultValue ? 1 : 0) > 0;
    }
}
