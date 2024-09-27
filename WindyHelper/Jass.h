#pragma once
#include "Init.h"
typedef int Player;
typedef int PlayerID;
typedef int unitstat;
typedef unsigned char* unit;
typedef DWORD unittype;
namespace Jass {
	const unittype UNIT_TYPE_HERO = 0;
	const unittype UNIT_TYPE_DEAD = 1;
	const unittype UNIT_TYPE_INVUL = 2;
	const unitstat UNIT_STAT_HP = 0;
	const unitstat UNIT_STAT_MAXHP = 1;
	const unitstat UNIT_STAT_MP = 2;
	const unitstat UNIT_STAT_MAXMP = 3;
	typedef char* (__fastcall* p_GetPlayerName)(int a1, int a2);
	extern p_GetPlayerName pGetPlayerName;
	typedef int(__fastcall* p_GetTypeInfoAddr)(int unit_item_code, int unused);
	extern p_GetTypeInfoAddr GetTypeIdInfoAddr;
	typedef void* (__fastcall* pGetUnitAbility)(unsigned char* unitaddr, int unused, int classid, int a3, int a4, int a5, int a6);
	extern pGetUnitAbility GetUnitAbility;
	typedef int(__fastcall* p_GetUnitLevel)(unsigned char* unitaddr, int unused);
	extern p_GetUnitLevel pGetUnitLevel;
	//
	void Init();
	bool IsOkayPtr(void* ptr, unsigned int size = 4);
	//
	char* GetPlayerName(PlayerID id);
	bool IsUnitType(unit u, unittype type);
	const char* GetObjectName(unit objaddress);
	int GetTypeId(unsigned char* unit_item_abil_etc_addr);
	int GetLocalPlayerId();
	int GetLocalPlayer();
	int Player(int number);
	unit GetLocalSelect();
	int GetUnitAbilityLevel(unsigned char* unitaddr, int id, BOOL checkavaiable = FALSE, BOOL CheckMemAccess = FALSE);
	float GetUnitX(unit u);
	float GetUnitY(unit y);
	int GetHeroMAXEXP(unsigned char* unit);
	int GetUnitLevel(unit u);
	int __stdcall GetUnitOwnerId(unit unitaddr);
	bool IsAbilityCooldown(unsigned char* unitaddr, int id);
	int* GetUnitCountAndUnitArray(unsigned char*** unitarray);
	float GetUnitStat(unit unitaddr, unitstat statNum);
	int GetAbilityManacost(unsigned char* pAbil);
	char* IdToChar(int u_or_abi);
	char* GetTypeChar(unsigned char* unit_item_abil_etc_addr);
}