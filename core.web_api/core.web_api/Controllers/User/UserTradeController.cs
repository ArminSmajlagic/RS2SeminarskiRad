﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace core.web_api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTradeController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;

    }
}
