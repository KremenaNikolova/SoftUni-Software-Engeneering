function generateReport() {
  const headers = document.querySelectorAll("thead th");
  const rows = document.querySelectorAll("tbody tr");

  const reportData = [];

  for (let i = 0; i < rows.length; i++) {
    const row = rows[i];
    const rowData = {};

    for (let j = 0; j < headers.length; j++) {
      const header = headers[j];

      const checkbox = header.querySelector('input[type="checkbox"]');
      if (checkbox.checked) {
        const propertyName = checkbox.name;
        const cellValue = row.querySelectorAll("td")[j].textContent;

        rowData[propertyName] = cellValue;
      }
    }
    reportData.push(rowData);
  }
  const outputTextarea = document.getElementById("output");
  outputTextarea.value = JSON.stringify(reportData, null, 2);
}
