#pragma once
#include "Init.h"
#define PROFILE_FILENAME "WindyHelper.txt"

void ProfileSetInt(LPCTSTR lpAppName, LPCTSTR lpKeyName, int val);
int ProfileGetInt(LPCTSTR lpAppName, LPCTSTR lpKeyName, int defaultVal);
int ProfileFetchInt(LPCTSTR lpAppName, LPCTSTR lpKeyName, int defaultVal);

void ProfileSetBool(LPCTSTR lpAppName, LPCTSTR lpKeyName, bool val);
bool ProfileGetBool(LPCTSTR lpAppName, LPCTSTR lpKeyName, bool defaultVal);
bool ProfileFetchBool(LPCTSTR lpAppName, LPCTSTR lpKeyName, bool defaultVal);

void ProfileSetFloat(LPCTSTR lpAppName, LPCTSTR lpKeyName, float val);
float ProfileGetFloat(LPCTSTR lpAppName, LPCTSTR lpKeyName, float defaultVal);
float ProfileFetchFloat(LPCTSTR lpAppName, LPCTSTR lpKeyName, float defaultVal);

void ProfileSetString(LPCTSTR lpAppName, LPCTSTR lpKeyName, LPCTSTR lpString);
const TCHAR* ProfileGetString(LPCTSTR lpAppName, LPCTSTR lpKeyName, LPCTSTR lpDefault);
const TCHAR* ProfileFetchString(LPCTSTR lpAppName, LPCTSTR lpKeyName, LPCTSTR lpDefault);

void Profile_Init(LPCTSTR fileName);
void InitFile(HMODULE selfModule);
