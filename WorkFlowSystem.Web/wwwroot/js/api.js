// api.js

function getToken() {
    return document.querySelector(
        'input[name="__RequestVerificationToken"]'
    ).value;
}

async function request(method, handler, body = null) {

    const options = {
        method,
        headers: {
            "RequestVerificationToken": getToken()
        }
    };

    if (body) {
        options.headers["Content-Type"] = "application/json";
        options.body = JSON.stringify(body);
    }

    const response = await fetch(`?handler=${handler}`, options);

    if (!response.ok) {
        throw new Error(await response.text());
    }

    if (response.status === 204) {
        return null;
    }

    return await response.json();
}

window.api = {
    get(handler) {
        return request("GET", handler);
    },

    post(handler, data) {
        console.log("POST", handler, data);
        return request("POST", handler, data);
    },

    delete(handler, id) {
        console.log("DELETE", handler, id);
        return request("POST", handler, { id });
    }
};