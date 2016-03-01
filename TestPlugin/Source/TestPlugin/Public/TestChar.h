#pragma once

#include "GameFramework/Character.h"
#include "TestChar.generated.h"

UCLASS()
class ATestChar : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	ATestChar();

	UPROPERTY(EditAnywhere, Category = "Test Char")
		int32			mAge;
	UPROPERTY(EditAnywhere, Category = "Test Char")
		FString			mName;
};