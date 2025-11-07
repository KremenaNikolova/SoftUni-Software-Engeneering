type Response = {
    code: number;
    text: string;
    printChars?: number;
}

function TextInfo(args: Response) {
    if ('printChars' in args) {
        return console.log(args.text.substring(0, args.printChars));
    }
    return console.log(args.text);
}

TextInfo({ code: 200, text: 'OK'});
TextInfo({ code: 201, text: 'Created'});
TextInfo({ code: 400, text: 'Bad Request', printChars: 4});
TextInfo({ code: 404, text: 'Not Found'});
TextInfo({ code: 404, text: 'Not Found', printChars: 3});
TextInfo({ code: 500, text: 'Internal Server Error', printChars: 1});