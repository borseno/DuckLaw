// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Duck.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\studyc#v2\Duck\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\studyc#v2\Duck\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Duck.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Duck.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\studyc#v2\Duck\Client\Pages\UserForm.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\studyc#v2\Duck\Client\Pages\UserForm.razor"
using Duck.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\studyc#v2\Duck\Client\Pages\UserForm.razor"
using System.IO;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class UserForm : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 58 "E:\studyc#v2\Duck\Client\Pages\UserForm.razor"
       
    Duck.Shared.Render render = new Duck.Shared.Render();

    async Task Create()
    {
        foreach (var file in selectedFiles)
        {
            Stream stream = file.OpenReadStream();
            MemoryStream ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            stream.Close();
            Random rnd = new Random();
            UploadedFile uploadedFile = new UploadedFile();
            Guid g = Guid.NewGuid();
            uploadedFile.FileName = Convert.ToString(g) + file.Name;
            uploadedFile.FileContent = ms.ToArray();
            ms.Close();
            await client.PostAsJsonAsync<UploadedFile>("/api/fileupload", uploadedFile);
            Message = $"{selectedFiles.Count} file(s) uploaded on server";
            this.StateHasChanged();
            await serv.CreateNewBlogPosttt(render);
            NavigationManager.NavigateTo("/Result/" + uploadedFile.FileName);
        }
    }
    string Message = "No file(s) selected";
    IReadOnlyList<IBrowserFile> selectedFiles;
    private void OnInputFileChange(InputFileChangeEventArgs e)
    {
        selectedFiles = e.GetMultipleFiles();
        Message = $"{selectedFiles.Count} file(s) selected";
        this.StateHasChanged();
    }
    protected async void OnInitializedAsync(MouseEventArgs arg)
    {
        await js.InvokeVoidAsync("Test");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient client { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Duck.Client.Service.IService serv { get; set; }
    }
}
#pragma warning restore 1591
