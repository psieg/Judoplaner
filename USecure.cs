using System;
using JwaWinBase;
using JwaWinType;
using JwaWinIoctl;
namespace USecure
{
    public struct TKeyData
    {
        public long KeyData1;
        public long KeyData2;
        public string KeyData3;
        public long KeyData4;
    } // end TKeyData

}

namespace USecure.Units
{
    public class USecure
    {
        // 2448895268
        // reveresstring(inttostr(x)) fist part
        // inttostr(x) second part
        // 1221125563512
        // reversestring(x) third part
        public const TKeyData myKey = 
    {8625988442, 1010794496, "2153655211221", 9567743} ;
        // 432256
        // inttostr(9999999-x) fourth part
        public static string GetLastErrorMessage()
        {
            string result;
            int i;
            uint code;
            TCHAR[] str = new TCHAR[255 + 1];
            DWORD bytesReturned;
            //@ Unsupported function or procedure: 'GetLastError'
            code = GetLastError();
            //@ Undeclared identifier(3): 'ZeroMemory'
            ZeroMemory(str, sizeof(str));
            //@ Undeclared identifier(3): 'FORMAT_MESSAGE_FROM_SYSTEM'
            //@ Unsupported function or procedure: 'NULL'
            //@ Unsupported function or procedure: 'FormatMessage'
            bytesReturned = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, null, code, NULL, str, sizeof(str), null);
            for (i = 0; i <= bytesReturned - 3; i ++ )
            {
                result = result + str[i];
            }
            return result;
        }

        public static string DeviceID(string DeviceLetter, __BOOL InfoInsteadOfKey)
        {
            string result;
            JwaWinType.HFILE hFile;
            DWORD bytesReturned;
            _GET_LENGTH_INFORMATION dataLen;
            _DRIVE_LAYOUT_INFORMATION dataLayout;
            _DISK_GEOMETRY dataGeo;
            string Info;
            int code;
            string Length;
            string Sig;
            string Cnt;
            string Entr;
            string Cyl;
            string MT;
            string TC;
            string ST;
            string BS;
            Info = "";
            result = "";
            code = 0;
            //@ Undeclared identifier(3): 'ZeroMemory'
            ZeroMemory(hFile, sizeof(hFile));
            //@ Undeclared identifier(3): 'GENERIC_READ'
            //@ Undeclared identifier(3): 'GENERIC_WRITE'
            //@ Undeclared identifier(3): 'FILE_SHARE_READ'
            //@ Undeclared identifier(3): 'FILE_SHARE_WRITE'
            //@ Undeclared identifier(3): 'OPEN_EXISTING'
            // FILE_FLAG_OVERLAPPED
            //@ Unsupported function or procedure: 'NULL'
            //@ Unsupported function or procedure: 'NULL'
            //@ Undeclared identifier(3): 'CreateFile'
            hFile = CreateFile(("\\\\.\\" + DeviceLetter + ':' as string), GENERIC_READ || GENERIC_WRITE, FILE_SHARE_READ || FILE_SHARE_WRITE, null, OPEN_EXISTING, NULL, NULL);
            //@ Undeclared identifier(3): 'INVALID_HANDLE_VALUE'
            if (hFile == INVALID_HANDLE_VALUE)
            {
                //@ Unsupported function or procedure: 'GetLastError'
                Info = Info + "CreateFile failed. Code: " + (GetLastError()).ToString() + " - " + GetLastErrorMessage();
                //@ Unsupported function or procedure: 'GetLastError'
                code = GetLastError();
            }
            else
            {
                bytesReturned = 0;
                //@ Undeclared identifier(3): 'ZeroMemory'
                ZeroMemory(dataLen, sizeof(dataLen));
                //@ Unsupported function or procedure: 'NULL'
                //@ Undeclared identifier(3): 'DeviceIoControl'
                if (DeviceIoControl(hFile, JwaWinIoctl.Units.JwaWinIoctl.IOCTL_DISK_GET_LENGTH_INFO, null, NULL, dataLen, sizeof(dataLen), bytesReturned, null))
                {
                    Info = Info + "Length: " + (((long)dataLen.Length)).ToString();
                    Length = (((long)dataLen.Length)).ToString();
                }
                else
                {
                    //@ Unsupported function or procedure: 'GetLastError'
                    Info = Info + "DeviceIoControl failed. Code: " + (GetLastError()).ToString() + " - " + GetLastErrorMessage();
                    //@ Unsupported function or procedure: 'GetLastError'
                    code = GetLastError();
                }
                Info = Info + (char)(13);
                bytesReturned = 0;
                //@ Undeclared identifier(3): 'ZeroMemory'
                ZeroMemory(dataLayout, sizeof(dataLayout));
                //@ Unsupported function or procedure: 'NULL'
                //@ Undeclared identifier(3): 'DeviceIoControl'
                if (DeviceIoControl(hFile, JwaWinIoctl.Units.JwaWinIoctl.IOCTL_DISK_GET_DRIVE_LAYOUT, null, NULL, dataLayout, sizeof(dataLayout), bytesReturned, null))
                {
                    Info = Info + "Layout: ";
                    Info = Info + "Sig:" + (dataLayout.Signature).ToString() + " Cnt:" + (dataLayout.PartitionCount).ToString() + " Entr:" + (((long)dataLayout.PartitionEntry[0].StartingOffset)).ToString();
                    Sig = (dataLayout.Signature).ToString();
                    Cnt = (dataLayout.PartitionCount).ToString();
                    Entr = (((long)dataLayout.PartitionEntry[0].StartingOffset)).ToString();
                }
                else
                {
                    //@ Unsupported function or procedure: 'GetLastError'
                    Info = Info + "DeviceIoControl failed. Code: " + (GetLastError()).ToString() + " - " + GetLastErrorMessage();
                    //@ Unsupported function or procedure: 'GetLastError'
                    code = GetLastError();
                }
                Info = Info + (char)(13);
                bytesReturned = 0;
                //@ Undeclared identifier(3): 'ZeroMemory'
                ZeroMemory(dataGeo, sizeof(dataGeo));
                //@ Unsupported function or procedure: 'NULL'
                //@ Undeclared identifier(3): 'DeviceIoControl'
                if (DeviceIoControl(hFile, JwaWinIoctl.Units.JwaWinIoctl.IOCTL_DISK_GET_DRIVE_GEOMETRY, null, NULL, dataGeo, sizeof(dataGeo), bytesReturned, null))
                {
                    Info = Info + "Geometry: ";
                    Info = Info + "Cyl:" + (((long)dataGeo.Cylinders)).ToString() + " MT:" + (((long)dataGeo.MediaType)).ToString() + " T/C:" + (((long)dataGeo.TracksPerCylinder)).ToString() + " S/T:" + (((long)dataGeo.SectorsPerTrack)).ToString() + " B/S:" + (((long)dataGeo.BytesPerSector)).ToString();
                    Cyl = (((long)dataGeo.Cylinders)).ToString();
                    MT = (((long)dataGeo.MediaType)).ToString();
                    TC = (((long)dataGeo.TracksPerCylinder)).ToString();
                    ST = (((long)dataGeo.SectorsPerTrack)).ToString();
                    BS = (((long)dataGeo.BytesPerSector)).ToString();
                }
                else
                {
                    //@ Unsupported function or procedure: 'GetLastError'
                    Info = Info + "DeviceIoControl failed. Code: " + (GetLastError()).ToString() + " - " + GetLastErrorMessage();
                    //@ Unsupported function or procedure: 'GetLastError'
                    code = GetLastError();
                }
            }
            if (InfoInsteadOfKey)
            {
                result = Info;
            }
            else if (code == 0)
            {
                result = Sig + '-' + Length + '-' + Cyl + MT + TC + ST + BS + '-' + Cnt + Entr;
            }
            else if (code == 2)
            {
                result = "NO_DEVICE";
            }
            else if (code == 5)
            {
                result = "ACCESS_DENIED";
            }
            else if (code == 21)
            {
                result = "NOT_READY";
            }
            return result;
        }

        public static string DeviceID(string DeviceLetter)
        {
            return DeviceID(DeviceLetter, false);
        }

        public static string KeyToString(TKeyData Key)
        {
            string result;
            //@ Unsupported function or procedure: 'ReverseString'
            //@ Unsupported function or procedure: 'ReverseString'
            result = ReverseString((Key.KeyData1).ToString()) + '-' + (Key.KeyData2).ToString() + '-' + ReverseString(Key.KeyData3) + '-' + (9999999 - Key.KeyData4).ToString();
            return result;
        }

        public static string ListDevices()
        {
            string result;
            int i;
            string tmp;
            result = "";
            for (i = 65; i <= 90; i ++ )
            {
                tmp = DeviceID((char)(i));
                result = result + (char)(i) + ": " + tmp + (char)(13);
                if ((tmp != "NO_DEVICE") && (tmp != "ACCESS_DENIED") && (tmp != "NOT_READY"))
                {
                    result = result + DeviceID((char)(i), true) + (char)(13);
                }
            }
            return result;
        }

    } // end USecure

}

