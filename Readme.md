## Controller
- Là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là một phương thức public (không được static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo

## View
- Là file .cshtml
- View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
```
{0} -> Tên Action
{1} -> Tên Controller
{2} -> Tên Area
options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
```

## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData

## Areas
- Là tên dùng để routing
- Là cấu trúc thư mục chứa MVC
- Thiết lập Area chứa controller bằng ``` [Area("AreaName")] ```
- Tạo cấu trúc thư mục
```
dotnet aspnet-codegenerator area Product
```

## Route
- endpoints.MapControllerRoute
- endpoints.MapAreaControllerRoute
- [AcceptVerbs("POST", "GET")]
- [Route("pattern")]
- [HttpGet] [HttpPost]

## Url Generation
### UrlHelper: Action, ActionLink, RouteUrl, Link
```
Url.Action("PlatnetInfo", "Planet", new {id = 1}, Context.Request.Scheme)

Url.RouteUrl("default", new {controller="First", action="HelloView", id=1, username="hehehe"})

### HtmlTagHelper: ``` <a> <form> <button> ```
Sử dụng thuộc tính:
```
asp-area="Area"
asp-action="Action"
asp-controller="Controller"
asp-route-...="123"
asp-route="default"
```