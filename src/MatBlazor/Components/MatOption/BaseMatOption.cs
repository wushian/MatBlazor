﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatOption
{
    public class BaseMatOption : ComponentBase
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected bool Disabled { get; set; }

        [Parameter]
        protected string Value { get; set; }
    }
}