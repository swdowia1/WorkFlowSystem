function getToken() {
    return document.querySelector(
        'input[name="__RequestVerificationToken"]'
    ).value;
}

async function request(method, url, body = null, reload = false, antiforgery = true) {

    const options = {
        method,
        headers: {}
    };

    if (antiforgery) {
        options.headers["RequestVerificationToken"] = getToken();
    }

    if (body) {
        options.headers["Content-Type"] = "application/json";
        options.body = JSON.stringify(body);
    }

    const response = await fetch(url, options);

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
        return request(
            "GET",
            `?handler=${handler}`
        );
    },

    post(handler, data, reload = false) {
        console.log("POST", handler, data, "reload", reload);

        return request(
            "POST",
            `?handler=${handler}`,
            data,
            reload
        );
    },


    // Web API POST
    postApi(url, data, reload = false) {
        console.log("POST API", url, data, "reload", reload);

        return request(
            "POST",
            url,
            data,
            reload,
            false
        );
    },


    delete(handler, id, reload = false) {
        console.log("DELETE", handler, id);

        return request(
            "POST",
            `?handler=${handler}`,
            { id },
            reload
        );
    }
};