﻿using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace ElectronicLogbookFunction
{
    public class FEmployeeLog : IFEmployeeLog
    {
        private IDEmployeeLog _iDEmployeeLog;

        public FEmployeeLog()
        {
            _iDEmployeeLog = new DEmployeeLog();
        }
        #region CREATE
        public EmployeeLog Create(int userId, EmployeeLog employeelog)
        {
            EEmployeeLog eEmployeeLog = EEmployeeLog(employeelog);
            eEmployeeLog.CreatedDate = DateTime.Now;
            eEmployeeLog.LogDate = DateTime.Now;
            eEmployeeLog.CreatedBy = userId;
            eEmployeeLog = _iDEmployeeLog.Create(eEmployeeLog);
            return (EmployeeLog(eEmployeeLog));
        }
        #endregion
        #region READ
        public EmployeeLog Read(int employeeLogId)
        {
            EEmployeeLog eEmployeeLog = _iDEmployeeLog.Read<EEmployeeLog>(a => a.EmployeeLogId == employeeLogId);
            return EmployeeLog(eEmployeeLog);
        }

        public List<EmployeeLog> Read()
        {
            List<EEmployeeLog> eEmployeeLogs = _iDEmployeeLog.List<EEmployeeLog>(a => true);
            return EmployeeLogs(eEmployeeLogs);
        }

        public List<EmployeeLog> Read(int employeeid, string sortBy)
        {
            List<EEmployeeLog> eEmployeeid = _iDEmployeeLog.Read<EEmployeeLog>(a => a.EmployeeId == employeeid, sortBy);
            return EmployeeLogs(eEmployeeid);
        }
        public LogType Readlogtype(int logtypeid)
        {
            ELogType eEmployeeLog = _iDEmployeeLog.Read<ELogType>(a => a.LogTypeId == logtypeid);
            return Logtype(eEmployeeLog);
        }
        #endregion
        #region UPDATE
        public EmployeeLog Update(int userId, EmployeeLog employeeLog)
        {
            var eEmployeeLog = EEmployeeLog(employeeLog);
            eEmployeeLog.UpdatedDate = DateTime.Now;
            eEmployeeLog.UpdatedBy = userId;
            eEmployeeLog = _iDEmployeeLog.Update(EEmployeeLog(employeeLog));
            return (EmployeeLog(eEmployeeLog));
        }
        #endregion
        #region DELETE
        public void Delete(int employeeLogId)
        {
            _iDEmployeeLog.Delete<EEmployeeLog>(a => a.EmployeeLogId == employeeLogId);
        }
        #endregion
        #region OTHER FUNCTION
        private List<EmployeeLog> EmployeeLogs(List<EEmployeeLog> eEmployeeLogs)
        {
            var returnEmployeeLog = eEmployeeLogs.Select(a => new EmployeeLog
            {
                SuccesLogin = a.SuccesLogin,
                CreatedDate = a.CreatedDate,
                LogDate = a.LogDate,
                UpdatedDate = a.UpdatedDate,
                LogName = a.LogName,
                CreatedBy = a.CreatedBy,
                EmployeeId = a.EmployeeId,
                EmployeeLogId = a.EmployeeLogId,
                LogTypeId = a.LogTypeId,
                UpdatedBy = a.UpdatedBy,
                EmployeeNumber = a.EmployeeNumber
            });
            return returnEmployeeLog.ToList();
        }
        private EEmployeeLog EEmployeeLog(EmployeeLog employeelog)
        {
            EEmployeeLog returnEEmployeeLog = new EEmployeeLog
            {
                SuccesLogin = employeelog.SuccesLogin,
                CreatedDate = employeelog.CreatedDate,
                LogDate = employeelog.LogDate,
                UpdatedDate = employeelog.UpdatedDate,
                LogName = employeelog.LogName,
                CreatedBy = employeelog.CreatedBy,
                EmployeeId = employeelog.EmployeeId,
                EmployeeLogId = employeelog.EmployeeLogId,
                LogTypeId = employeelog.LogTypeId,
                UpdatedBy = employeelog.UpdatedBy,
                EmployeeNumber = employeelog.EmployeeNumber
            };
            return returnEEmployeeLog;
        }
        private EmployeeLog EmployeeLog(EEmployeeLog eEmployeeLog)
        {
            EmployeeLog returnEmployeeLog = new EmployeeLog
            {
                SuccesLogin = eEmployeeLog.SuccesLogin,
                CreatedDate = eEmployeeLog.CreatedDate,
                LogDate = eEmployeeLog.LogDate,
                UpdatedDate = eEmployeeLog.UpdatedDate,
                LogName = eEmployeeLog.LogName,
                CreatedBy = eEmployeeLog.CreatedBy,
                EmployeeId = eEmployeeLog.EmployeeId,
                EmployeeLogId = eEmployeeLog.EmployeeLogId,
                LogTypeId = eEmployeeLog.LogTypeId,
                UpdatedBy = eEmployeeLog.UpdatedBy,
                EmployeeNumber = eEmployeeLog.EmployeeNumber
            };
            return returnEmployeeLog;
        }
        private LogType Logtype(ELogType eLogtype)
        {
            LogType returnEmployeeLogtype = new LogType
            {
                CreatedDate = eLogtype.CreatedDate,
                UpdatedDate = eLogtype.UpdatedDate,
                CreatedBy = eLogtype.CreatedBy,
                LogTypeId = eLogtype.LogTypeId,
                UpdatedBy = eLogtype.UpdatedBy,
                Name = eLogtype.Name
            };
            return returnEmployeeLogtype;
        }
        #endregion
    }
}
