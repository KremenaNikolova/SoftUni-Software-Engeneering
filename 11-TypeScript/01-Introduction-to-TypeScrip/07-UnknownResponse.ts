function UnknownResponse(data: unknown) :string {
    if (data
        && typeof data === 'object'
        && 'value' in data
        && typeof data.value === 'string') {
        return data.value;
    }
    return "-"
}

console.log(UnknownResponse({ code: 200, text: 'Ok', value: [1, 2, 3] })); // -
console.log(UnknownResponse({ code: 301, text: 'Moved Permanently', value: 'New Url' })); //New Url
console.log(UnknownResponse({ code: 201, text: 'Created', value: { name: 'Test', age: 20 } })); // -
console.log(UnknownResponse({ code: 201, text: 'Created', value: 'Object Created' })); //Object Created
console.log(UnknownResponse({ code: 404, text: 'Not found' })); // -
console.log(UnknownResponse({ code: 500, text: 'Internal Server Error' })); // -