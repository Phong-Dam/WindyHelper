#include "Init.h"
#include "tchar.h"
#include "Profile.h"
TCHAR WindyHelperConfig[MAX_PATH] = { 0 };

void ProfileSetInt(LPCTSTR lpAppName, LPCTSTR lpKeyName, int val) {
	TCHAR temp[10] = { 0 };
	_stprintf_s(temp, sizeof(temp) / sizeof(TCHAR), TEXT("%d"), val);
	WritePrivateProfileString(
		lpAppName,
		lpKeyName,
		temp,
		WindyHelperConfig
	);
}

int ProfileGetInt(LPCTSTR lpAppName, LPCTSTR lpKeyName, int defaultVal) {
	return GetPrivateProfileInt(lpAppName, lpKeyName, defaultVal, WindyHelperConfig);
}

int ProfileFetchInt(LPCTSTR lpAppName, LPCTSTR lpKeyName, int defaultVal) {
	int rv = ProfileGetInt(lpAppName, lpKeyName, -17236);
	if (rv == -17236) {
		rv = defaultVal;
		ProfileSetInt(lpAppName, lpKeyName, rv);
	}
	return rv;
}

void ProfileSetFloat(LPCTSTR lpAppName, LPCTSTR lpKeyName, float val) {
	TCHAR temp[10] = { 0 };
	_stprintf_s(temp, sizeof(temp) / sizeof(TCHAR), TEXT("%.4f"), val);
	WritePrivateProfileString(
		lpAppName,
		lpKeyName,
		temp,
		WindyHelperConfig
	);
}

float ProfileGetFloat(LPCTSTR lpAppName, LPCTSTR lpKeyName, float defaultVal) {
	TCHAR def[20] = { 0 };
	TCHAR rv[20] = { 0 };
	_stprintf_s(def, sizeof(def) / sizeof(TCHAR), TEXT("%.4f"), defaultVal);
	GetPrivateProfileString(lpAppName, lpKeyName, def, rv, sizeof(rv), WindyHelperConfig);
	return (float)_tstof(rv);
}

float ProfileFetchFloat(LPCTSTR lpAppName, LPCTSTR lpKeyName, float defaultVal) {
	float rv = ProfileGetFloat(lpAppName, lpKeyName, -28356.0f);
	if (rv == -28356.0f) {
		rv = defaultVal;
		ProfileSetFloat(lpAppName, lpKeyName, rv);
	}
	return rv;
}

static TCHAR ProfileStringTmp[256];
const TCHAR* ProfileGetString(LPCTSTR lpAppName, LPCTSTR lpKeyName, LPCTSTR lpDefault) {
	GetPrivateProfileString(lpAppName, lpKeyName, lpDefault, ProfileStringTmp, 256, WindyHelperConfig);
	return ProfileStringTmp;
}

void ProfileSetString(LPCTSTR lpAppName, LPCTSTR lpKeyName, LPCTSTR lpString) {
	WritePrivateProfileString(lpAppName, lpKeyName, lpString, WindyHelperConfig);
}

const TCHAR* ProfileFetchString(LPCTSTR lpAppName, LPCTSTR lpKeyName, LPCTSTR lpDefault) {
	ProfileGetString(lpAppName, lpKeyName, TEXT("iNvALidStrInG"));
	if (_tcscmp(ProfileStringTmp, TEXT("iNvALidStrInG")) == 0) {
		ProfileSetString(lpAppName, lpKeyName, lpDefault);
		return ProfileGetString(lpAppName, lpKeyName, lpDefault);
	}
	return ProfileStringTmp;
}

void Profile_Init(LPCTSTR fileName) {
	_tcscpy_s(WindyHelperConfig, MAX_PATH, fileName);
}

void ProfileSetBool(LPCTSTR lpAppName, LPCTSTR lpKeyName, bool val)
{
	ProfileSetInt(lpAppName, lpKeyName, val ? 1 : 0);
}

bool ProfileGetBool(LPCTSTR lpAppName, LPCTSTR lpKeyName, bool defaultVal)
{
	return ProfileGetInt(lpAppName, lpKeyName, defaultVal ? 1 : 0) > 0;
}

bool ProfileFetchBool(LPCTSTR lpAppName, LPCTSTR lpKeyName, bool defaultVal)
{
	return ProfileFetchInt(lpAppName, lpKeyName, defaultVal ? 1 : 0) > 0;
}


char ModulePathz[MAX_PATH];
char ModuleFileNamez[MAX_PATH];
char RootPathz[MAX_PATH];
void InitFile(HMODULE selfModule) {
	char buffer[MAX_PATH];
	GetModuleFileNameA(selfModule, (LPCH)buffer, MAX_PATH);
	char* filename = strrchr(buffer, '\\');
	strcpy_s(ModuleFileNamez, MAX_PATH, filename + 1);
	*filename = '\0';
	strcpy_s(ModulePathz, MAX_PATH, buffer);
	strcpy_s(RootPathz, sizeof(RootPathz), ModulePathz);
	char path[MAX_PATH];
	sprintf_s(path, "%s\\%s", RootPathz, PROFILE_FILENAME);
	Profile_Init(path);
}