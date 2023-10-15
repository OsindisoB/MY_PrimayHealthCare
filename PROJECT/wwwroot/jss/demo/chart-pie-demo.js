//// Set new default font family and font color to mimic Bootstrap's default styling
//Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
//Chart.defaults.global.defaultFontColor = '#858796';

//// Pie Chart Example
//var ctx = document.getElementById("myPieChart");
//var myPieChart = new Chart(ctx, {
//  type: 'doughnut',
//  data: {
//    labels: ["Direct", "Referral", "Social"],
//    datasets: [{
//      data: [55, 30, 15],
//      backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc'],
//      hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf'],
//      hoverBorderColor: "rgba(234, 236, 244, 1)",
//    }],
//  },
//  options: {
//    maintainAspectRatio: false,
//    tooltips: {
//      backgroundColor: "rgb(255,255,255)",
//      bodyFontColor: "#858796",
//      borderColor: '#dddfeb',
//      borderWidth: 1,
//      xPadding: 15,
//      yPadding: 15,
//      displayColors: false,
//      caretPadding: 10,
//    },
//    legend: {
//      display: false
//    },
//    cutoutPercentage: 80,
//  },
//});

// Donut Chart Example
var ctx = document.getElementById("myPieChart");
var patientAgeDonutChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: ["18-25", "26-35", "36-45", "46-55", "56+"],
        datasets: [{
            data: [25, 30, 20, 15, 10], // Example distribution percentages for age groups
            backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', '#f6c23e', '#e74a3b'],
            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf', '#d6891c', '#c43e2f'],
            hoverBorderColor: "rgba(234, 236, 244, 1)",
        }],
    },
    options: {
        maintainAspectRatio: false,
        tooltips: {
            backgroundColor: "rgb(255,255,255)",
            bodyFontColor: "#858796",
            borderColor: '#dddfeb',
            borderWidth: 1,
            xPadding: 15,
            yPadding: 15,
            displayColors: false,
            caretPadding: 10,
        },
        legend: {
            display: true,
            position: 'right',
            labels: {
                usePointStyle: true,
                padding: 20,
            }
        },
        cutoutPercentage: 70, // Adjust the size of the inner circle (0-100)
    }
});
