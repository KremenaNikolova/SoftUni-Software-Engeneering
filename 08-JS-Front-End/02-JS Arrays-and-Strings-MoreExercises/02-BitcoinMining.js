function mining(days) {
  const bitcountCurrency = 11949.16;
  const goldCurrency = 67.51;

  let daysCounter = 0;
  let amountInLv = 0;
  let bitcounts = 0;
  let firstboughtDay = 0;

  for (let day of days) {
    daysCounter++;
    if (daysCounter % 3 === 0) {
      day -= day * 0.3;
    }
    amountInLv += day * goldCurrency;

    while (amountInLv >= bitcountCurrency) {
      if (bitcounts === 0) {
        firstboughtDay = daysCounter;
      }

      bitcounts++;
      amountInLv -= bitcountCurrency;
    }
  }

  console.log(`Bought bitcoins: ${bitcounts}`);
  if (firstboughtDay !== 0) {
    console.log(`Day of the first purchased bitcoin: ${firstboughtDay}`);
  }

  console.log(`Left money: ${amountInLv.toFixed(2)} lv.`);
}

mining([100, 200, 300]);
mining([50, 100]);
mining([3124.15, 504.212, 2511.124]);
