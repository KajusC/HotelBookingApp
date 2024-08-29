
export function validatePassword(password, addToast)
{
    if(password.length < 8 || password.length > 20) {
        addToast({
            id: Date.now().toString(),
            title: "Error",
            description: "Password must be at least 8 characters and at most 20 characters",
            type: "error",
        });
        return false;
    }
    if(password === password.toLowerCase() || password === password.toUpperCase()) {
        addToast({
            id: Date.now().toString(),
            title: "Error",
            description: "Password must contain at least one uppercase and one lowercase letter",
            type: "error",
        });
        return false;
    }
    if(!password.match(/[0-9]/g)) {
        addToast({
            id: Date.now().toString(),
            title: "Error",
            description: "Password must contain at least one number",
            type: "error",
        });
        return false;
    }
        return true;
}

export function validateName(name, addToast)
{
    if(name.length < 2 || name.length > 20) {
        addToast({
            id: Date.now().toString(),
            title: "Error",
            description: "Name must be at least 2 characters and at most 20 characters",
            type: "error",
        });
        return false;
    }
        return true;
}

export function validateLastName(lastName, addToast)
{
    if(lastName.length < 2 || lastName.length > 20) {
        addToast({
            id: Date.now().toString(),
            title: "Error",
            description: "Last name must be at least 2 characters and at most 20 characters",
            type: "error",
        });
        return false;
    }
    return true;
}

export function validateEmail(email, addToast)
{
    if (!email.includes("@")) {
        addToast({
            id: Date.now().toString(),
            title: "Error",
            description: "Invalid email",
            type: "error",
        });
        return false;
    }
    return true;
}

export function validateUsername(username, addToast)
{
    if(username.length < 2 || username.length > 20) {
        addToast({
            id: Date.now().toString(),
            title: "Error",
            description: "Username must be at least 2 characters and at most 20 characters",
            type: "error",
        });
        return false;
    }
    return true;
}

