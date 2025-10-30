function PrintFirday13th(data: unknown): void {
  enum Months {
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December,
  }

  if (data && Array.isArray(data)) {
    data.forEach((el) => {
      if (el instanceof Date && el.getDate() === 13 && el.getDay() === 5) {
        let monthNumber: number = el.getMonth();
        let month = Months[monthNumber];
        console.log(`${el.getDate()}-${month}-${el.getFullYear()}`);
      }
    });
  }
}

PrintFirday13th([
  {},
  new Date(2025, 4, 13),
  null,
  new Date(2025, 5, 13),
  "13-09-2023",
  new Date(2025, 6, 13),
]);

PrintFirday13th([
  new Date(2024, 0, 13),
  new Date(2024, 1, 13),
  new Date(2024, 2, 13),
  new Date(2024, 3, 13),
  new Date(2024, 4, 13),
  new Date(2024, 5, 13),
  new Date(2024, 6, 13),
  new Date(2024, 7, 13),
  new Date(2024, 8, 13),
  new Date(2024, 9, 13),
  new Date(2024, 10, 13),
  new Date(2024, 11, 13),
]);
