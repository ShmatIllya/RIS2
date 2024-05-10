package lw1_build2.spring.model;

import jakarta.persistence.*;
import lw1_build2.spring.model.enums.BikeStatus;

@Entity
@Table(name = "bike_lw1")
public class Bike {
    @Id
    @Column(name = "id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    @Column(name = "name")
    private String name;

    @Enumerated(EnumType.STRING)
    @Column(name = "status")
    private BikeStatus status;

    @Column(name = "rent_price_for_hour")
    private Double rentPriceForHour;

    @Column(name = "rent_price_for_three_hours")
    private Double rentPriceForThreeHours;

    @Column(name = "rent_price_for_day")
    private Double rentPriceForDay;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public BikeStatus getStatus() {
        return status;
    }

    public void setStatus(BikeStatus status) {
        this.status = status;
    }

    public Double getRentPriceForHour() {
        return rentPriceForHour;
    }

    public void setRentPriceForHour(Double rentPriceForHour) {
        this.rentPriceForHour = rentPriceForHour;
    }

    public Double getRentPriceForThreeHours() {
        return rentPriceForThreeHours;
    }

    public void setRentPriceForThreeHours(Double rentPriceForThreeHours) {
        this.rentPriceForThreeHours = rentPriceForThreeHours;
    }

    public Double getRentPriceForDay() {
        return rentPriceForDay;
    }

    public void setRentPriceForDay(Double rentPriceForDay) {
        this.rentPriceForDay = rentPriceForDay;
    }

    @Override
    public String toString() {
        return "Bike{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", status=" + status +
                ", rentPriceForHour=" + rentPriceForHour +
                ", rentPriceForThreeHours=" + rentPriceForThreeHours +
                ", rentPriceForDay=" + rentPriceForDay +
                '}';
    }
}
