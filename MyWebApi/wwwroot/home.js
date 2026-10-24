
async function getResponse() {
    try {
        const postData = {
            firstname: document.querySelector(".firstname").value,
            lastname: document.querySelector(".lastname").value,
            password: document.querySelector(".password").value,
            email: document.querySelector(".email").value
        }
        const responsePost = await fetch('API/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)

        });
        if (!responsePost.ok) { throw new Error(`HTTP error! status:' ${responsePost.status()}`) }
        const res = await responsePost.json();
        console.log('post data:', res);
        sessionStorage.setItem('CurrentUser', JSON.stringify(res))
    }
    catch (e) {
        alert(e.message)
    }
}
async function getResposeLogin() {
   
    const LogData = {
        password: document.querySelector(".password2").value,
        email: document.querySelector(".email2").value

    }
    try {
    const responsePost = await fetch('API/Users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(LogData)

    });
        if (!responsePost.ok) { throw new Error(`HTTP error! status:' ${responsePost.status()}`) }
        alert("your login was succsess")
        const res = await responsePost.json();
        console.log('post data:', res);
        sessionStorage.setItem('CurrentUser', JSON.stringify(res))
        alert("העדכון התבצע בהצלחה")
    }
    catch (e) {
        alert(e.message)
    }
}