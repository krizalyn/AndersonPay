var ctx = document.getElementById("lineChart").getContext("2d");

var gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
gradientStroke.addColorStop(0, '#10ba54');
gradientStroke.addColorStop(1, '#39ef82');

var gradientFill = ctx.createLinearGradient(500, 0, 100, 0);

gradientFill.addColorStop(0, "rgba(100, 220, 128, 0.8)");
gradientFill.addColorStop(0.5, "rgba(200, 100, 128, 0.65)");
gradientFill.addColorStop(1, "rgba(100, 250, 128, 0.5)");




Chart.defaults.global.defaultFontFamily = "Raleway";
Chart.defaults.global.defaultFontSize = 16;
Chart.defaults.global.defaultFontColor = "Black";
var LineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
        datasets: [{
            label: "2017",
            borderColor: gradientStroke,
            pointBorderColor: gradientStroke,
            pointBackgroundColor: gradientStroke,
            pointHoverBackgroundColor: gradientStroke,
            pointHoverBorderColor: 'red',
            pointBorderWidth: 1,
            pointHoverRadius: 7,
            pointHoverBorderWidth: 1,
            pointRadius: 3,
            fill: true,
            backgroundColor: gradientFill,
            borderWidth: 2,
            data: [200, 100, 232, 182, 363, 281, 294, 334, 384, 237, 421, 239]
        }]
    },
    options: {
        elements:{
            line: {
                tension: 0.2
            }
        },
        title: {
            display: true,
            text: "Invoice Sales",
            padding: 10,
            fontSize: 24,
            position: "top"
        },
        scales: {
            yAxes: [{
                gridLines: {
                    show: true,
                    drawTicks: false,
                    color: "rgba(30, 30, 30, 0.4)",
                    zeroLineColor: "rgba(30, 30, 30, 0.4)",
                },
                scaleLabel: {
                    display: true,
                    labelString: 'Total Invoice Sales (2017)'
                },
                ticks: {
                    padding: 10,
                    beginAtZero: true
                }
            }],
            xAxes: [{
                gridLines: {
                    zeroLineColor: "transparent",
                    color: "rgba(0, 0, 0, 0)",
                },
                scaleLabel: {
                    display: true,
                    labelString: 'Months'
                }
            }]
        }
    }

})