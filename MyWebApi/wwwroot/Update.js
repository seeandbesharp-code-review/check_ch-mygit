
var obj =JSON.parse( sessionStorage.getItem('CurrentUser'))

   const firstname= document.querySelector(".firstname").value= obj.firstname
    const lastname= document.querySelector(".lastname").value= obj.lastname
    const password= document.querySelector(".password").value= obj.password
    const email= document.querySelector(".email").value= obj.email
async function setDetails() {
    console.log("put")
    const UpdateData = {
        firstname: document.querySelector(".firstname").value,
        lastname: document.querySelector(".lastname").value,
        password: document.querySelector(".password").value,
        email: document.querySelector(".email").value
    }

    console.log(obj.userId)
    try {
        const responsePut = await fetch(`API/Users/${obj.userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(UpdateData)

        });
        if (responsePut.ok) {
            UpdateData.email = document.querySelector(".email").value
            UpdateData.firstname = document.querySelector(".firstname").value
            UpdateData.lastname = document.querySelector(".lastname").value
            UpdateData.password = document.querySelector(".password").value
            sessionStorage.setItem('Put data', JSON.stringify(UpdateData))
            window.location.href = "UserDetails.html";
        }
        else {
            console.log('error')
        }
    
    }
    catch(e) {
        alert(e.message)
    }
}