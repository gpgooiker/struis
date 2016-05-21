using UnityEngine;
using System.Collections;

public static class DeviceRotation
{

	private static Quaternion referenceRotation = Quaternion.identity;

	public static float StruisSpeedAngle ()
	{
		Quaternion deviceRotation = DeviceRotation.Get (0, 0, 1);
		Quaternion eliminationOfXY = Quaternion.Inverse (
			                             Quaternion.FromToRotation (referenceRotation * Vector3.forward, 
				                             deviceRotation * Vector3.forward)
		                             );
		Quaternion rotationZ = eliminationOfXY * deviceRotation;
		return rotationZ.eulerAngles.z;
	}

	public static float WorldRotationAngleX ()
	{
		Quaternion deviceRotation = DeviceRotation.Get (1, 0, 0);
		Quaternion eliminationOfYZ = Quaternion.Inverse (
			                             Quaternion.FromToRotation (referenceRotation * Vector3.forward, 
				                             deviceRotation * Vector3.forward)
		                             );
		Quaternion rotationZ = eliminationOfYZ * deviceRotation;
		return rotationZ.eulerAngles.x;
	}


	public static float WorldRotationAngleY ()
	{
		Quaternion deviceRotation = DeviceRotation.Get (0, 1, 0);
		Quaternion eliminationOfYZ = Quaternion.Inverse (
			                             Quaternion.FromToRotation (referenceRotation * Vector3.forward, 
				                             deviceRotation * Vector3.forward)
		                             );
		Quaternion rotationZ = eliminationOfYZ * deviceRotation;
		return rotationZ.eulerAngles.y;
	}

	private static bool gyroInitialized = false;

	public static bool HasGyroscope {
		get {
			return SystemInfo.supportsGyroscope;
		}
	}

	public static Quaternion Get (int x, int y, int z)
	{
		if (!gyroInitialized) {
			InitGyro ();
		}

		return HasGyroscope
			? ReadGyroscopeRotation (x, y, z)
				: Quaternion.identity;
	}

	private static void InitGyro ()
	{
		if (HasGyroscope) {
			Input.gyro.enabled = true;                // enable the gyroscope
			Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)
		}
		gyroInitialized = true;
	}

	private static Quaternion ReadGyroscopeRotation (int x, int y, int z)
	{
		return new Quaternion (0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion (x, y, z, 0);
	}
}