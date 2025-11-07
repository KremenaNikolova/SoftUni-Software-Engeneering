type CarBody = {
  material: string;
  state: string;
} & MoreInfo;

type Tires = {
  airPressure: number;
  condition: string;
} & MoreInfo;

type Engine = {
  horsepower: number;
  oilDensity: number;
} & MoreInfo;

type MoreInfo = {
  partName: string;
  runDiagnostics(): string;
};

const runDiagnostics = function (this: { partName: string }): string {
    return this.partName;
}

function CarDiagnostic(carBody: CarBody, tires: Tires, engine: Engine) {
    console.log(carBody.runDiagnostics());
    console.log(tires.runDiagnostics());
    console.log(engine.runDiagnostics());
}

CarDiagnostic(
  {
    material: "aluminum",
    state: "scratched",
    partName: "Car Body",
    runDiagnostics,
  },
  {
    airPressure: 30,
    condition: "needs change",
    partName: "Tires",
    runDiagnostics,
  },
  {
    horsepower: 300,
    oilDensity: 780,
    partName: "Engine", 
    runDiagnostics
  }
);
