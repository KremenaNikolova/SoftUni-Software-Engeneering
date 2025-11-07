type Param = string | number | string[];
type Operation = 'Index' | 'Length' | 'Add';
type Operand = number;

function Operator(param: Param, operation: Operation, operand: Operand) {

    if (typeof param !== 'number' && operation === 'Index') {
        if (Array.isArray(param)) return param[operand];
        if (typeof param === 'string') return param.charAt(operand);
    }

    if (typeof param !== 'number' && operation === 'Length') {
        if (Array.isArray(param)) return param.length;
        if (typeof param === 'string') return param.length % operand;
    }

    if (!Array.isArray(param) && operation === 'Add') {
        if (typeof param === 'string') return operand += parseInt(param);
        return operand + param;
    }
}

console.log(Operator(['First', 'Second', 'Third'], 'Index', 1));
console.log(Operator('string', 'Index', 1));
console.log(Operator(['Just', 'Two'], 'Length', 5));
console.log(Operator('short string1', 'Length', 5));
console.log(Operator('7', 'Add', 3));
console.log(Operator(11, 'Add', 3));