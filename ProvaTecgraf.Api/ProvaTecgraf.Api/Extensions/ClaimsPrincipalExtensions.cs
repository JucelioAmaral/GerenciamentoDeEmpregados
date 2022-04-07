﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProvaTecgraf.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //Todo classe de extensão deve ser static, senão não conseguirá chamar ele.
        public static string GetUserName(this ClaimsPrincipal user)//O nome do método não tem nenhuma relação com o nome da classe, tem a ver com o primeiro parâmetro passado, ou seja, deve ser: "this ClaimsPrincipal <parametro>", funcionando de forma correta.
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
        //Todo método de extensão deve ser static, senão não conseguirá chamar ele.
        public static int GetUserId(this ClaimsPrincipal user)//O nome do método não tem nenhuma relação com o nome da classe, tem a ver com o primeiro parâmetro passado, ou seja, deve ser: "this ClaimsPrincipal <parametro>", funcionando de forma correta.
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
