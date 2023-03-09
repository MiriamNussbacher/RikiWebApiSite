

const saveUserInSessionStorage = (data) => {
    sessionStorage.setItem('CurrentUser', JSON.stringify(data));
};

const signInSucceeded = async (user) => {
    const userToJson = await user.json();
    saveUserInSessionStorage(userToJson);
    window.location.href = "userDetails.html";
};

const createUserJsonToSendSignIn = () => {
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    return JSON.stringify({ Password: password, Email: email });

};

const signIn = async () => {
    //const user = await fetch(`api/users?email=${email}&password=${password}`);
    const userToSend = createUserJsonToSendSignIn();
    const user = await fetch(`api/users/login`,
        {
            method: 'POST',
            body: userToSend,
            headers: {
                'Content-Type': 'application/json'
            }
        }
    );
    if (user.status == 200) {
        await signInSucceeded(user); 
    }
    if (user.status == 401) {
        alert("userName or password are invalid");
    }
    if (user.status == 400) {

        alert("requierd fields"); 
    }


}

const createUserToSignUp = () => {
    const email = document.getElementById("emailSignUp").value;
    const password = document.getElementById("passwordSignUp").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    return JSON.stringify({ FirstName: firstName, LastName: lastName, Password: password, Email: email });

}

const signUp = async () => {

    const userToSignUp = createUserToSignUp();
    const user = await fetch(`api/users`,
        {
            method: 'POST',
            body: userToSignUp,
            headers: {
                'Content-Type': 'application/json'
            }
        }
    );
    if (user.status == 201) {
        const userToJson = await user.json();
        saveUserInSessionStorage(userToJson);
        alert('המשתמש נרשם בהצלחה');

    }

    if (user.status == 400) {
        alert('requierd fields')
    }

}

const displayUserName = () => {
    
    const divName = document.getElementById("displayUserName");
    divName.innerHTML = `שלום ${JSON.parse(sessionStorage.getItem('CurrentUser')).firstName}`; 

}


const createUserToUpdate = () => {
    const email = document.getElementById("emailUpdate").value;
    const password = document.getElementById("passwordUpdate").value;
    const firstName = document.getElementById("firstNameUpdate").value;
    const lastName = document.getElementById("lastNameUpdate").value;
    return JSON.stringify({ FirstName: firstName, LastName: lastName, Password: password, Email: email });

}

const update = async () => {
    const userToUpdate = createUserToUpdate(); //JSON.stringify({ FirstName: firstName, LastName: lastName, Password: password, Email: email });
    const id = JSON.parse(sessionStorage.getItem('CurrentUser')).userId;
    const user = await fetch(`api/users/${id}`,
        {
            method: 'PUT',
            body: userToUpdate,
            headers: {
                'Content-Type': 'application/json'
            }
        }
    );

    if (user.status == 200) {
        const userToJson = await user.json();
        saveUserInSessionStorage(userToJson);

        alert('הפרטים עודכנו בהצלחה');

    }

    if (user.status == 400)
    {
        alert(`update failed`); 
    }

}


const visibleUpdate = () => {
    const updateDiv = document.getElementById("updateUser");
    updateDiv.style.visibility = "visible";

}


const checkStrenghPassword = async() => {

    const password = document.getElementById("passwordSignUp").value;
    const response = await fetch(`api/passwords`, {
        method: 'POST',
        body: JSON.stringify(password),
        headers: {
            'Content-Type': 'application/json'
        }

   
    });

    const score =  await response.json(); 
    document.getElementById("passwordStrengh").value = score; 
}