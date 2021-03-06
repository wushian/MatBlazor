﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatSelect
{
    public class BaseMatSelect : BaseMatComponent
    {
        private string _value;

        public BaseMatSelect()
        {
            ClassMapper
                .Add("mdc-select")
                .If("mdc-select--outlined", () => Outlined)
                .If("mdc-select--disabled", () => Disabled);
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

//        [Parameter]
        protected bool Enhanced { get; set; } = false;

        [Parameter]
        protected bool Outlined { get; set; }

        [Parameter]
        protected bool Disabled { get; set; }

        [Parameter]
        protected string Label { get; set; }

        [Parameter]
        protected string Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    ValueChanged?.Invoke(value);
                }
            }
        }

        [Parameter]
        protected Action<string> ValueChanged { get; set; }

        public void OnChangeHandler(UIChangeEventArgs e)
        {
            Value = (string) e.Value;
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matSelect.init", Ref);
        }
    }
}