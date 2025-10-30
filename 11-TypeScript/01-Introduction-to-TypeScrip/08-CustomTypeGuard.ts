function CustomTypeGuard(data: unknown): data is string[]{
    let result = data && Array.isArray(data) && data.length > 0 && data.every(el => typeof el === 'string') ? true : false;
    return result;
}

console.log(CustomTypeGuard({}));
console.log(CustomTypeGuard({test: 'one'}));
console.log(CustomTypeGuard([]));
console.log(CustomTypeGuard(undefined));
console.log(CustomTypeGuard(null));
console.log(CustomTypeGuard([12, 13]));
console.log(CustomTypeGuard(['test', 123]));
console.log(CustomTypeGuard(['a', 'b', 'c']));