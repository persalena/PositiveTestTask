using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ActionResult
    {
        private bool _isSuccess;
        private ResultCode _code;

        public ActionResult(bool isSuccess, ResultCode code)
        {
            this._isSuccess = isSuccess;
            this._code = code;
        }

        public bool IsSuccess
        {
            get
            {
                return this._isSuccess;
            }
        }

        public ResultCode Code
        {
            get
            {
                return _code;
            }
        }
    }
}
