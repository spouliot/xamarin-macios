using System;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.HomeKit {

	[iOS (8,0)]
	[TV (10,0)]
	[Native]
	public enum HMError : nint {
		AlreadyExists                           = 1,
		NotFound                                = 2,
		InvalidParameter                        = 3,
		AccessoryNotReachable                   = 4,
		ReadOnlyCharacteristic                  = 5,
		WriteOnlyCharacteristic                 = 6,
		NotificationNotSupported                = 7,
		OperationTimedOut                       = 8,
		AccessoryPoweredOff                     = 9,
		AccessDenied                            = 10,
		ObjectAssociatedToAnotherHome           = 11,
		ObjectNotAssociatedToAnyHome            = 12,
		ObjectAlreadyAssociatedToHome           = 13,
		AccessoryIsBusy                         = 14,
		OperationInProgress                     = 15,
		AccessoryOutOfResources                 = 16,
		InsufficientPrivileges                  = 17,
		AccessoryPairingFailed                  = 18,
		InvalidDataFormatSpecified              = 19,
		NilParameter                            = 20,
		UnconfiguredParameter                   = 21,
		InvalidClass                            = 22,
		OperationCancelled                      = 23,
		RoomForHomeCannotBeInZone               = 24,
		NoActionsInActionSet                    = 25,
		NoRegisteredActionSets                  = 26,
		MissingParameter                        = 27,
		FireDateInPast                          = 28,
		RoomForHomeCannotBeUpdated              = 29,
		ActionInAnotherActionSet                = 30,
		ObjectWithSimilarNameExistsInHome       = 31,
		HomeWithSimilarNameExists               = 32,
		RenameWithSimilarName                   = 33,
		CannotRemoveNonBridgeAccessory          = 34,
		NameContainsProhibitedCharacters        = 35,
		NameDoesNotStartWithValidCharacters     = 36,
		UserIDNotEmailAddress                   = 37,
		UserDeclinedAddingUser                  = 38,
		UserDeclinedRemovingUser                = 39,
		UserDeclinedInvite                      = 40,
		UserManagementFailed                    = 41,
		RecurrenceTooSmall                      = 42,
		InvalidValueType                        = 43,
		ValueLowerThanMinimum                   = 44,
		ValueHigherThanMaximum                  = 45,
		StringLongerThanMaximum                 = 46,
		HomeAccessNotAuthorized                 = 47,
		OperationNotSupported                   = 48,
		MaximumObjectLimitReached               = 49,
		AccessorySentInvalidResponse            = 50,
		StringShorterThanMinimum                = 51,
		GenericError                            = 52,
		SecurityFailure                         = 53,
		CommunicationFailure                    = 54,
		MessageAuthenticationFailed             = 55,
		InvalidMessageSize                      = 56,
		AccessoryDiscoveryFailed                = 57,
		ClientRequestError                      = 58,
		AccessoryResponseError                  = 59,
		NameDoesNotEndWithValidCharacters       = 60,
		AccessoryIsBlocked                      = 61,
		InvalidAssociatedServiceType            = 62,
		ActionSetExecutionFailed                = 63,
		ActionSetExecutionPartialSuccess        = 64,
		ActionSetExecutionInProgress            = 65,
		AccessoryOutOfCompliance                = 66,
		DataResetFailure                        = 67,
		NotificationAlreadyEnabled              = 68,
		RecurrenceMustBeOnSpecifiedBoundaries   = 69,
		DateMustBeOnSpecifiedBoundaries         = 70,
		CannotActivateTriggerTooFarInFuture     = 71,
		RecurrenceTooLarge                      = 72,
		ReadWritePartialSuccess                 = 73,
		ReadWriteFailure                        = 74,
		NotSignedIntoiCloud                     = 75,
		KeychainSyncNotEnabled                  = 76,
		CloudDataSyncInProgress                 = 77,
		NetworkUnavailable                      = 78,
		AddAccessoryFailed                      = 79,
		MissingEntitlement                      = 80,
		CannotUnblockNonBridgeAccessory			= 81,
		DeviceLocked							= 82,
		CannotRemoveBuiltinActionSet			= 83,
		LocationForHomeDisabled					= 84,
		NotAuthorizedForLocationServices		= 85,
		// iOS 9.3
		ReferToUserManual						= 86,
		// iOS 10.0
		InvalidOrMissingAuthorizationData       = 87,
		BridgedAccessoryNotReachable            = 88,
		NotAuthorizedForMicrophoneAccess        = 89,
		// iOS 10.2
		IncompatibleNetwork                     = 90,
	}

	
	// conveniance enum (ObjC uses NSString)
	[iOS (8,0)]
	[TV (10,0)]
	public enum HMCharacteristicType {
		None,

		[Field ("HMCharacteristicTypePowerState")]
		PowerState,

		[Field ("HMCharacteristicTypeHue")]
		Hue,

		[Field ("HMCharacteristicTypeSaturation")]
		Saturation,

		[Field ("HMCharacteristicTypeBrightness")]
		Brightness,

		[Field ("HMCharacteristicTypeTemperatureUnits")]
		TemperatureUnits,

		[Field ("HMCharacteristicTypeCurrentTemperature")]
		CurrentTemperature,

		[Field ("HMCharacteristicTypeTargetTemperature")]
		TargetTemperature,

		[Field ("HMCharacteristicTypeCurrentHeatingCooling")]
		CurrentHeatingCooling,

		[Field ("HMCharacteristicTypeTargetHeatingCooling")]
		TargetHeatingCooling,

		[Field ("HMCharacteristicTypeCoolingThreshold")]
		CoolingThreshold,

		[Field ("HMCharacteristicTypeHeatingThreshold")]
		HeatingThreshold,

		[Obsolete ("This value does not exist anymore and will always return null")]
		HeatingCoolingStatus,

		[Field ("HMCharacteristicTypeCurrentRelativeHumidity")]
		CurrentRelativeHumidity,

		[Field ("HMCharacteristicTypeTargetRelativeHumidity")]
		TargetRelativeHumidity,

		[Field ("HMCharacteristicTypeCurrentDoorState")]
		CurrentDoorState,

		[Field ("HMCharacteristicTypeTargetDoorState")]
		TargetDoorState,

		[Field ("HMCharacteristicTypeObstructionDetected")]
		ObstructionDetected,

		[Field ("HMCharacteristicTypeName")]
		Name,

		[Field ("HMCharacteristicTypeManufacturer")]
		Manufacturer,

		[Field ("HMCharacteristicTypeModel")]
		Model,

		[Field ("HMCharacteristicTypeSerialNumber")]
		SerialNumber,

		[Field ("HMCharacteristicTypeIdentify")]
		Identify,

		[Field ("HMCharacteristicTypeRotationDirection")]
		RotationDirection,

		[Field ("HMCharacteristicTypeRotationSpeed")]
		RotationSpeed,

		[Field ("HMCharacteristicTypeOutletInUse")]
		OutletInUse,

		[Field ("HMCharacteristicTypeVersion")]
		Version,

		[Field ("HMCharacteristicTypeLogs")]
		Logs,

		[Field ("HMCharacteristicTypeAudioFeedback")]
		AudioFeedback,

		[Field ("HMCharacteristicTypeAdminOnlyAccess")]
		AdminOnlyAccess,

		[Field ("HMCharacteristicTypeMotionDetected")]
		MotionDetected,

		[Field ("HMCharacteristicTypeCurrentLockMechanismState")]
		CurrentLockMechanismState,

		[Field ("HMCharacteristicTypeTargetLockMechanismState")]
		TargetLockMechanismState,

		[Field ("HMCharacteristicTypeLockMechanismLastKnownAction")]
		LockMechanismLastKnownAction,

		[Field ("HMCharacteristicTypeLockManagementControlPoint")]
		LockManagementControlPoint,

		[Field ("HMCharacteristicTypeLockManagementAutoSecureTimeout")]
		LockManagementAutoSecureTimeout,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeAirParticulateDensity")]
		AirParticulateDensity,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeAirParticulateSize")]
		AirParticulateSize,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeAirQuality")]
		AirQuality,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeBatteryLevel")]
		BatteryLevel,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCarbonDioxideDetected")]
		CarbonDioxideDetected,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCarbonDioxideLevel")]
		CarbonDioxideLevel,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCarbonDioxidePeakLevel")]
		CarbonDioxidePeakLevel,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCarbonMonoxideDetected")]
		CarbonMonoxideDetected,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCarbonMonoxideLevel")]
		CarbonMonoxideLevel,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCarbonMonoxidePeakLevel")]
		CarbonMonoxidePeakLevel,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeChargingState")]
		ChargingState,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeContactState")]
		ContactState,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCurrentSecuritySystemState")]
		CurrentSecuritySystemState,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCurrentHorizontalTilt")]
		CurrentHorizontalTilt,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCurrentLightLevel")]
		CurrentLightLevel,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCurrentPosition")]
		CurrentPosition,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeCurrentVerticalTilt")]
		CurrentVerticalTilt,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeFirmwareVersion")]
		FirmwareVersion,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeHardwareVersion")]
		HardwareVersion,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeHoldPosition")]
		HoldPosition,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeInputEvent")]
		InputEvent,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeLeakDetected")]
		LeakDetected,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeOccupancyDetected")]
		OccupancyDetected,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeOutputState")]
		OutputState,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypePositionState")]
		PositionState,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeSmokeDetected")]
		SmokeDetected,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeSoftwareVersion")]
		SoftwareVersion,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeStatusActive")]
		StatusActive,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeStatusFault")]
		StatusFault,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeStatusJammed")]
		StatusJammed,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeStatusLowBattery")]
		StatusLowBattery,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeStatusTampered")]
		StatusTampered,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeTargetSecuritySystemState")]
		TargetSecuritySystemState,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeTargetHorizontalTilt")]
		TargetHorizontalTilt,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeTargetPosition")]
		TargetPosition,

		[iOS (9,0)]
		[Field ("HMCharacteristicTypeTargetVerticalTilt")]
		TargetVerticalTilt,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeStreamingStatus")]
		StreamingStatus,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeSetupStreamEndpoint")]
		SetupStreamEndpoint,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeSupportedVideoStreamConfiguration")]
		SupportedVideoStreamConfiguration,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeSupportedAudioStreamConfiguration")]
		SupportedAudioStreamConfiguration,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeSupportedRTPConfiguration")]
		SupportedRtpConfiguration,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeSelectedStreamConfiguration")]
		SelectedStreamConfiguration,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeVolume")]
		Volume,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeMute")]
		Mute,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeNightVision")]
		NightVision,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeOpticalZoom")]
		OpticalZoom,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeDigitalZoom")]
		DigitalZoom,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeImageRotation")]
		ImageRotation,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMCharacteristicTypeImageMirroring")]
		ImageMirroring,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeActive")]
		Active,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeCurrentAirPurifierState")]
		CurrentAirPurifierState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeTargetAirPurifierState")]
		TargetAirPurifierState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeCurrentFanState")]
		CurrentFanState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeCurrentHeaterCoolerState")]
		CurrentHeaterCoolerState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeCurrentHumidifierDehumidifierState")]
		CurrentHumidifierDehumidifierState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeCurrentSlatState")]
		CurrentSlatState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeWaterLevel")]
		WaterLevel,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeFilterChangeIndication")]
		FilterChangeIndication,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeFilterLifeLevel")]
		FilterLifeLevel,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeFilterResetChangeIndication")]
		FilterResetChangeIndication,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeLockPhysicalControls")]
		LockPhysicalControls,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeSwingMode")]
		SwingMode,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeTargetHeaterCoolerState")]
		TargetHeaterCoolerState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeTargetHumidifierDehumidifierState")]
		TargetHumidifierDehumidifierState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeTargetFanState")]
		TargetFanState,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeSlatType")]
		SlatType,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeCurrentTilt")]
		CurrentTilt,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeTargetTilt")]
		TargetTilt,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeOzoneDensity")]
		OzoneDensity,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeNitrogenDioxideDensity")]
		NitrogenDioxideDensity,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeSulphurDioxideDensity")]
		SulphurDioxideDensity,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypePM2_5Density")]
		PM2_5Density,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypePM10Density")]
		PM10Density,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeVolatileOrganicCompoundDensity")]
		VolatileOrganicCompoundDensity,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeDehumidifierThreshold")]
		DehumidifierThreshold,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMCharacteristicTypeHumidifierThreshold")]
		HumidifierThreshold,

		[iOS (9,0), Watch (2,0), TV (10,0)]
		[Field ("HMCharacteristicTypeSecuritySystemAlarmType")]
		SecuritySystemAlarmType,
	}

	// conveniance enum (ObjC uses NSString)
	[iOS (8,0)]
	[TV (10,0)]
	public enum HMCharacteristicMetadataUnits {
		None,
		Celsius,
		Fahrenheit,
		Percentage,
		ArcDegree,
		[iOS (8,3)]
		Seconds,
		[iOS (9,3)][Watch(2,2)]
		Lux,
		[iOS (10,0), Watch (3,0)]
		PartsPerMillion,
		[iOS (10,0), Watch (3,0)]
		MicrogramsPerCubicMeter,
	}

	// conveniance enum (ObjC uses NSString)
	[iOS (8,0)]
	[TV (10,0)]
	[Flags]
	public enum HMServiceType {
		None,

		[Field ("HMServiceTypeLightbulb")]
		LightBulb,

		[Field ("HMServiceTypeSwitch")]
		Switch,

		[Field ("HMServiceTypeThermostat")]
		Thermostat,

		[Field ("HMServiceTypeGarageDoorOpener")]
		GarageDoorOpener,

		[Field ("HMServiceTypeAccessoryInformation")]
		AccessoryInformation,

		[Field ("HMServiceTypeFan")]
		Fan,

		[Field ("HMServiceTypeOutlet")]
		Outlet,

		[Field ("HMServiceTypeLockMechanism")]
		LockMechanism,

		[Field ("HMServiceTypeLockManagement")]
		LockManagement,

		[iOS (9,0)]
		[Field ("HMServiceTypeAirQualitySensor")]
		AirQualitySensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeBattery")]
		Battery,

		[iOS (9,0)]
		[Field ("HMServiceTypeCarbonDioxideSensor")]
		CarbonDioxideSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeCarbonMonoxideSensor")]
		CarbonMonoxideSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeContactSensor")]
		ContactSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeDoor")]
		Door,

		[iOS (9,0)]
		[Field ("HMServiceTypeHumiditySensor")]
		HumiditySensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeLeakSensor")]
		LeakSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeLightSensor")]
		LightSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeMotionSensor")]
		MotionSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeOccupancySensor")]
		OccupancySensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeSecuritySystem")]
		SecuritySystem,

		[iOS (9,0)]
		[Field ("HMServiceTypeStatefulProgrammableSwitch")]
		StatefulProgrammableSwitch,

		[iOS (9,0)]
		[Field ("HMServiceTypeStatelessProgrammableSwitch")]
		StatelessProgrammableSwitch,

		[iOS (9,0)]
		[Field ("HMServiceTypeSmokeSensor")]
		SmokeSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeTemperatureSensor")]
		TemperatureSensor,

		[iOS (9,0)]
		[Field ("HMServiceTypeWindow")]
		Window,

		[iOS (9,0)]
		[Field ("HMServiceTypeWindowCovering")]
		WindowCovering,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMServiceTypeCameraRTPStreamManagement")]
		CameraRtpStreamManagement,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMServiceTypeCameraControl")]
		CameraControl,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMServiceTypeMicrophone")]
		Microphone,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMServiceTypeSpeaker")]
		Speaker,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMServiceTypeDoorbell")]
		Doorbell,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMServiceTypeAirPurifier")]
		AirPurifier,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMServiceTypeVentilationFan")]
		VentilationFan,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMServiceTypeFilterMaintenance")]
		FilterMaintenance,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMServiceTypeHeaterCooler")]
		HeaterCooler,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMServiceTypeHumidifierDehumidifier")]
		HumidifierDehumidifier,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMServiceTypeSlats")]
		Slats,
	}

	// conveniance enum (ObjC uses NSString)
	[iOS (8,0)]
	[TV (10,0)]
	public enum HMCharacteristicMetadataFormat {
		None,
		Bool,
		Int,
		Float,
		String,
		Array,
		Dictionary,
		UInt8,
		UInt16,
		UInt32,
		UInt64,
		Data,
		Tlv8
	}

	[iOS (8,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueDoorState : nint {
		Open = 0,
		Closed,
		Opening,
		Closing,
		Stopped
	}

	[iOS (8,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueHeatingCooling : nint {
		Off = 0,
		Heat,
		Cool,
		Auto
	}

	[iOS (8,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueRotationDirection : nint {
		Clockwise = 0,
		CounterClockwise
	}

	[iOS (8,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueTemperatureUnit : nint {
		Celsius = 0,
		Fahrenheit
	}

	[iOS (8,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueLockMechanismState : nint {
		Unsecured = 0,
		Secured,
		Jammed,
		Unknown
	}

	[iOS (8,0)]
	[TV (10,0)]
	[Native]
	// in iOS 8.3 this was renamed HMCharacteristicValueLockMechanismLastKnownAction but that would be a breaking change for us
	public enum HMCharacteristicValueLockMechanism : nint {
		LastKnownActionSecuredUsingPhysicalMovementInterior = 0,
		LastKnownActionUnsecuredUsingPhysicalMovementInterior,
		LastKnownActionSecuredUsingPhysicalMovementExterior,
		LastKnownActionUnsecuredUsingPhysicalMovementExterior,
		LastKnownActionSecuredWithKeypad,
		LastKnownActionUnsecuredWithKeypad,
		LastKnownActionSecuredRemotely,
		LastKnownActionUnsecuredRemotely,
		LastKnownActionSecuredWithAutomaticSecureTimeout,
		LastKnownActionSecuredUsingPhysicalMovement,
		LastKnownActionUnsecuredUsingPhysicalMovement,
	}

	[iOS (9,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueAirParticulate : nint {
		Size2_5 = 0,
		Size10
	}

	[iOS (9,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueCurrentSecuritySystemState : nint {
		StayArm = 0,
		AwayArm,
		NightArm,
		Disarmed,
		Triggered
	}

	[iOS (9,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValuePositionState : nint {
		Closing = 0,
		Opening,
		Stopped
	}

	[iOS (9,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueTargetSecuritySystemState : nint {
		StayArm = 0,
		AwayArm,
		NightArm,
		Disarm
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueBatteryStatus : nint {
		Normal = 0,
		Low
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueJammedStatus : nint {
		None = 0,
		Jammed
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueTamperedStatus : nint {
		None = 0,
		Tampered
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueLeakStatus : nint {
		None = 0,
		Detected
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueSmokeDetectionStatus : nint {
		None = 0,
		Detected
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueChargingState : nint {
		None = 0,
		InProgress,
		[iOS (10,2), Watch (3,1,1), TV (10,1)]
		NotChargeable,
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueContactState : nint {
		None = 0,
		Detected
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueStatusFault : nint {
		NoFault = 0,
		GeneralFault
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueCarbonMonoxideDetectionStatus : nint {
		NotDetected = 0,
		Detected
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueCarbonDioxideDetectionStatus : nint {
		NotDetected = 0,
		Detected
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueOccupancyStatus : nint {
		NotOccupied = 0,
		Occupied
	}

	[Watch (3,0), TV (10,0), iOS (10,0)]
	[Native]
	public enum HMCharacteristicValueSecuritySystemAlarmType : nint {
		NoAlarm = 0,
		Unknown
	}

	// conveniance enum (ObjC uses NSString)
	[iOS (9,0)]
	[TV (10,0)]
	public enum HMActionSetType {
		Unknown = -1,
		WakeUp,
		Sleep,
		HomeDeparture,
		HomeArrival,
		UserDefined,
		[iOS (10,0), Watch (3,0)]
		TriggerOwned,
	}

	[iOS (9,0)]
	[TV (10,0)]
	// conveniance enum (ObjC uses NSString)
	public enum HMAccessoryCategoryType {
		[Field ("HMAccessoryCategoryTypeOther")]
		Other = 0,

		[Field ("HMAccessoryCategoryTypeSecuritySystem")]
		SecuritySystem,

		[Field ("HMAccessoryCategoryTypeBridge")]
		Bridge,

		[Field ("HMAccessoryCategoryTypeDoor")]
		Door,

		[Field ("HMAccessoryCategoryTypeDoorLock")]
		DoorLock,

		[Field ("HMAccessoryCategoryTypeFan")]
		Fan,

#if !WATCH && !TVOS
		[Obsolete ("Use GarageDoorOpener instead")]
		DoorOpener,

		[Field ("HMAccessoryCategoryTypeGarageDoorOpener")]
		GarageDoorOpener = DoorOpener,
#else
		[Field ("HMAccessoryCategoryTypeGarageDoorOpener")]
		GarageDoorOpener,
#endif

		[Field ("HMAccessoryCategoryTypeLightbulb")]
		Lightbulb,

		[Field ("HMAccessoryCategoryTypeOutlet")]
		Outlet,

		[Field ("HMAccessoryCategoryTypeProgrammableSwitch")]
		ProgrammableSwitch,

		[Field ("HMAccessoryCategoryTypeSensor")]
		Sensor,

		[Field ("HMAccessoryCategoryTypeSwitch")]
		Switch,

		[Field ("HMAccessoryCategoryTypeThermostat")]
		Thermostat,

		[Field ("HMAccessoryCategoryTypeWindow")]
		Window,

		[Field ("HMAccessoryCategoryTypeWindowCovering")]
		WindowCovering,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMAccessoryCategoryTypeRangeExtender")]
		RangeExtender,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMAccessoryCategoryTypeIPCamera")]
		IPCamera,

		[iOS (10,0), Watch (3,0)]
		[Field ("HMAccessoryCategoryTypeVideoDoorbell")]
		VideoDoorbell,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMAccessoryCategoryTypeAirPurifier")]
		AirPurifier,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMAccessoryCategoryTypeAirHeater")]
		AirHeater,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMAccessoryCategoryTypeAirConditioner")]
		AirConditioner,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMAccessoryCategoryTypeAirHumidifier")]
		AirHumidifier,

		[NoWatch]
		[iOS (10,2), TV (10,1)]
		[Field ("HMAccessoryCategoryTypeAirDehumidifier")]
		AirDehumidifier,
	}

	[iOS (9,0)]
	[TV (10,0)]
	// conveniance enum (ObjC uses NSString)
	public enum HMSignificantEvent {
		Sunrise,
		Sunset,
	}

	[iOS (9,0)]
	[TV (10,0)]
	[Native]
	public enum HMCharacteristicValueAirQuality : nint {
		Unknown = 0,
		Excellent,
		Good,
		Fair,
		Inferior,
		Poor
	}

	[iOS (10,0)]
	[TV (10,0)]
	[Native]
	public enum HMCameraStreamState : nuint
	{
		Starting = 1,
		Streaming = 2,
		Stopping = 3,
		NotStreaming = 4
	}

	[iOS (10,0)]
	[TV (10,0)]
	[Native]
	public enum HMCameraAudioStreamSetting : nuint
	{
		Muted = 1,
		IncomingAudioAllowed = 2,
		BidirectionalAudioAllowed = 3
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueLockPhysicalControlsState : nint {
		NotLocked = 0,
		Locked,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueCurrentAirPurifierState : nint {
		Inactive = 0,
		Idle,
		Active,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueTargetAirPurifierState : nint {
		Manual = 0,
		Automatic,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueCurrentSlatState : nint {
		Stationary = 0,
		Jammed,
		Oscillating,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueSlatType : nint {
		Horizontal = 0,
		Vertical,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueFilterChange : nint {
		NotNeeded = 0,
		Needed,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueCurrentFanState : nint {
		Inactive = 0,
		Idle,
		Active,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueTargetFanState : nint {
		Manual = 0,
		Automatic,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueCurrentHeaterCoolerState : nint {
		Inactive = 0,
		Idle,
		Heating,
		Cooling,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueTargetHeaterCoolerState : nint {
		Automatic = 0,
		Heat,
		Cool,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueCurrentHumidifierDehumidifierState : nint {
		Inactive = 0,
		Idle,
		Humidifying,
		Dehumidifying,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueTargetHumidifierDehumidifierState : nint {
		Automatic = 0,
		Humidify,
		Dehumidify,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueSwingMode : nint {
		Disabled = 0,
		Enabled,
	}

	[NoWatch]
	[TV (10,1), iOS (10,2)]
	[Native]
	public enum HMCharacteristicValueActivationState : nint {
		Inactive = 0,
		Active,
	}
}
