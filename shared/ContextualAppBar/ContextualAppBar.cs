using Microsoft.AspNetCore.Components;
using System;

namespace Dorc.Shared
{
	public class ContextualAppBar : ComponentBase, IDisposable
	{
		[CascadingParameter]
		public IContextualAppBarParent Parent { get; set; }
		
		[Parameter]
		public RenderFragment Title { get; set; }

		[Parameter]
		public RenderFragment Actions { get; set; }

		protected override void OnInitialized()
		{
			base.OnInitialized();
			Parent.SetContextualAppBar(this);
		}

		public void Dispose()
		{
			Parent?.SetContextualAppBar(null);
		}
	}
}