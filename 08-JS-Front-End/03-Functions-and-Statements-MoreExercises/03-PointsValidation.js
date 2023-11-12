function poinsValidation(pointsLocation) {
  distanceValidation(pointsLocation[0], pointsLocation[1], 0, 0);
  distanceValidation(pointsLocation[2], pointsLocation[3], 0, 0);
  distanceValidation(
    pointsLocation[0],
    pointsLocation[1],
    pointsLocation[2],
    pointsLocation[3]
  );

  function distanceValidation(x1, y1, x2, y2) {
    const distance = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
    let status = "invalid";
    if (Number.isInteger(distance)) {
      status = "valid";
    }

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status}`);
  }
}

poinsValidation([3, 0, 0, 4]);
poinsValidation([2, 1, 1, 1]);
