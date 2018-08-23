﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Common;
using LinkerPad.Common.CustomeAuthorizeAttribute;
using LinkerPad.Data;
using LinkerPad.Models.DailyActivity;
using LinkerPad.Models.Response;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Controllers
{
    public class EquipmentController : ApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IEquipmentLogic _equipmentLogic;
        private readonly IProjectLogic _projectLogic;

        public EquipmentController(
            ITokenHelper tokenHelper,
            IEquipmentLogic equipmentLogic,
            IProjectLogic projectLogic)
        {
            _tokenHelper = tokenHelper;
            _equipmentLogic = equipmentLogic;
            _projectLogic = projectLogic;
        }
    }
}