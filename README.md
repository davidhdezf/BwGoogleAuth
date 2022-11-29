# BwGoogleAuth
A simple Blazor component to authenticate using Google Credentials. The component creates a button using the next Google Identity guidelines:

https://developers.google.com/identity/gsi/web/guides/display-button#javascript

<img width="441" alt="image" src="https://user-images.githubusercontent.com/21249323/204426394-b7149e42-d617-4ab4-9d1a-f29aff6d8f82.png">

Once the user has logged in, the credentials will be retrieved in a credential class which contains the Email, Name and User Id. 

![image](https://user-images.githubusercontent.com/21249323/204427187-031136e7-3ba0-4c24-bfa3-39180298b85a.png)

# Prerequisites

1. Have a Google API Client id
2. Include your site's domain in the Authorized JavaScript origins box

You can follow the next instructions.

https://developers.google.com/identity/gsi/web/guides/get-google-api-clientid

# Use the component

### 1. Install
The component is distributed as a [BwGoogleAuth nuget package](https://www.nuget.org/packages/BwGoogleAuth). You can add them to your project in one of the following ways
- Install the package from command line by running `dotnet add package BwGoogleAuth`
- Add the project from the Visual Nuget Package Manager

Latest version is 1.0.1

### 2. Import the namespace

Open the `_Imports.razor` file of your Blazor application and add this line `@using BwGoogleAuth`.

### 3. Include Javascript Files

Open  `wwwroot/index.html` (Blazor WebAssembly) and include this snippet before the blazor.webassembly.js <script>: 

```html
    <script src="https://accounts.google.com/gsi/client"></script>
    <script src="_content/BwGoogleAuth/JsInterop.js"></script>
```
### 4. Use the component

Open the `Index.razor` file and define the next variable
    
```razor
@code{
    public Credential usercredential= new Credential();
}
```
Add the GoogleAuth component, bind it to the variable and add your Google Client Id. Set the Hide parameter to true to hide the button once the user has logged in.
```razor    
<GoogleAuth
Hide=true
ClientId="Your-Client-Id"
@bind-UserCredential=@usercredential
/>
```
Once the user has logged in, the information will be stored in the usercredential variable.  
    
You can display the user information by calling the variable properties. 
```razor        
@if (usercredential.IsLogged)
{
    

    <div>
    <ul>
      <li>Name:@usercredential.Name</li>
      <li>Email:@usercredential.Email</li>
      <li>User Id:@usercredential.UserId</li>

    </ul>  
    </div>

}
```
  
    

