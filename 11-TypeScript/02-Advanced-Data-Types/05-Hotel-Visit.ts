type simplified = (({
  number: 1; train(): void;
} | {
  number: 2; dine(): void;
}) & ({
  hallway: 'A'; pass?: 'Guest'
} | {
  hallway: 'C'
}))
  | {
  number: 3; hallway: 'A' | 'C';sleep(): void;
  };


function visitFloor(floor: simplified
) {
    switch (floor.number) {
        case 1: floor.train(); return;
        case 2: floor.dine(); return;
        case 3: floor.sleep(); return;
    }
}

//condition:
//floors are 1, 2, 3;
//hallways are A, C;
//functions are train, dine, sleep; they return void;
//1 is always train, 2 is always dine, 3 is always sleep
//1 + A, C + train | 1 + A + train + pass?: 'Guest';
//2 + A, C + dine | 2 + A + dine + pass?: 'Guest';
//3 + A, C + sleep

//valid inputs
visitFloor({ train() { }, number: 1, hallway: 'A', pass: 'Guest' });
visitFloor({ dine() { }, number: 2, hallway: 'A' });
visitFloor({ sleep() { }, number: 3, hallway: 'C' });
visitFloor({ train() { }, number: 1, hallway: 'C' });
visitFloor({ train() { }, number: 1, hallway: 'A' });
visitFloor({ dine() { }, number: 2, hallway: 'A', pass: 'Guest' });
visitFloor({ sleep() { }, number: 3, hallway: 'A' });
visitFloor({ dine() { }, number: 2, hallway: 'C' });


//invalid inputs
// visitFloor({ train() { }, number: 4, hallway: 'A' });
// visitFloor({ train() { }, number: 1, hallway: 'C', pass: 'Guest' });
// visitFloor({ train() { }, number: 2, hallway: 'A' });
// visitFloor({ train() { }, number: 3, hallway: 'C' });
// visitFloor({ train() { }, number: 3, hallway: 'C', pass: 'Guest' });

// visitFloor({ dine() { }, number: 1, hallway: 'A' });
// visitFloor({ dine() { }, number: 1, hallway: 'B' });
// visitFloor({ dine() { }, number: 1, hallway: 'C' });
// visitFloor({ dine() { }, number: 3, hallway: 'C' });
// visitFloor({ dine() { }, number: 2, hallway: 'C', pass: 'Guest' });
// visitFloor({ dine() { }, number: 1, hallway: 'A', pass: 'Guest' });

// visitFloor({ sleep() { }, number: 3, hallway: 'D' });
// visitFloor({ sleep() { }, number: 4, hallway: 'C' });
// visitFloor({ sleep() { }, number: 1, hallway: 'C' });
// visitFloor({ sleep() { }, number: 1, hallway: 'A' });
// visitFloor({ sleep() { }, number: 2, hallway: 'A' });
// visitFloor({ sleep() { }, number: 2, hallway: 'C' });





