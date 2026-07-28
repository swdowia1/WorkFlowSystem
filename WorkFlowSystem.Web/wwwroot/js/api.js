function getToken() {
    return document.querySelector(
        'input[name="__RequestVerificationToken"]'
    ).value;
}

async function request(method, handler, body = null, reload = false) {

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

    if (reload) {
        location.reload();
        return;
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

    post(handler, data, reload = false) {
        console.log("POST", handler, data, "reload", reload);
        return request("POST", handler, data, reload);
    },

    delete(handler, id, reload = false) {
        console.log("DELETE", handler, id);
        return request("POST", handler, { id }, reload);
    }
};