﻿using MeowvBlog.Services.Signature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeowvBlog.Web.Controllers.Apis
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class SignatureController : ControllerBase
    {
        private readonly ISignatureService _signService;

        public SignatureController()
        {
            _signService = PlusEngine.Instance.Resolve<ISignatureService>();
        }

        /// <summary>
        /// 获取所有签名的类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("type")]
        public async Task<IList<NameValue<int>>> GetSignatureType()
        {
            return await _signService.GetSignatureType();
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<string> GetSignature(string name, int id)
        {
            return await _signService.GetSignature(name, id);
        }
    }
}