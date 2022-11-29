// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

var bwjs = {}





bwjs.initGoogle = function (dotNetObjectRef,clientid) {

    handleCredentialResponse = function (response) {

        console.log("Encoded JWT ID token: " + response.credential);

        dotNetObjectRef.invokeMethodAsync('SaveCredentials', response.credential);
    }




    google.accounts.id.initialize({
        client_id: clientid,
        callback: handleCredentialResponse
    });
    google.accounts.id.renderButton(
        document.getElementById("buttonDiv"),
        { theme: "outline", size: "large" }  // customization attributes
    );
    //  google.accounts.id.prompt(); // also display the One Tap dialog
}







