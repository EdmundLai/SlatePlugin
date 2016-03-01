
#include "TestPluginPrivatePCH.h"
#include "TestChar.h"
#include "TestLib.h"

ATestChar::ATestChar() : Super()
{
	mAge = myPrint("hello world", 123);
	mName = "yangx";
}