const UNKNOWN = "UNKNOWN";
const UNAVAILABLE = "UNAVAILABLE";
const BASE_API = "";
const DEFAULT_HEADERS = {
    "Accept": "application/json",
    "Content-Type": "application/json"
};

CreateEventListener("spendingPingButton", "spendingPingResult", "/spending/ping", "GET");
CreateEventListener("spendingAddButton", "spendingAddResult", "/spending/add", "POST");
CreateEventListener("spendingUpdateButton", "spendingUpdateResult", "/spending/update/1", "PUT");
CreateEventListener("spendingGetButton", "spendingGetResult", "/spending/get/2", "GET");
CreateEventListener("spendingDeleteButton", "spendingDeleteResult", "/spending/delete/3", "DELETE");

async function CreateEventListener(buttonId, resultId, requestUrl, requestMethod) {
    let button = document.getElementById(buttonId);

    button.addEventListener("click", async function () {
        let resultOutput = document.getElementById(resultId);
        let output = await makeRequest(requestUrl, requestMethod);
        resultOutput.innerHTML = output;
    });
}

async function makeRequest(url, method)
{
    const response = await fetch(BASE_API + url, {
        method: method,
        headers: DEFAULT_HEADERS
    })

    let result = await ReturnResult(response);
    return result;
}

async function ReturnResult(response)
{
    if (response.ok === true) {
        const responseModel = await response.json();
        return JSON.stringify(responseModel);
    }
    else {
        return UNAVAILABLE;
    }
}