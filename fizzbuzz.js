for (let i = 1; i <= 20; i++) {
    if (i % 15 === 0){            //15の倍数は3と5の倍数でもあるので、最初にチェックする
        console.log("FizzBuzz");
    }
    else if (i % 3 === 0){
        console.log("Fizz");
    }
    else if (i % 5 === 0){
        console.log("Buzz");
    }
    else{
        console.log(i);
    } 
}
