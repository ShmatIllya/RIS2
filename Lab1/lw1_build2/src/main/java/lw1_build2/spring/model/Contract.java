package lw1_build2.spring.model;

import jakarta.persistence.*;
import lw1_build2.spring.model.enums.RentDuration;

import java.sql.Timestamp;
import java.time.LocalDateTime;

@Entity
@Table(name = "contract_lw1")
public class Contract {
    @Id
    @Column(name = "id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "customer_id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int customerIDInt;

    @Column(name = "bike_id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int bikeIDInt;

    @ManyToOne
    @JoinColumn(name = "customer_id", insertable = false, updatable = false)
    private Customer customerId;

    @ManyToOne
    @JoinColumn(name = "bike_id", insertable = false, updatable = false)
    private Bike bikeId;

    @Enumerated(EnumType.STRING)
    @Column(name = "rent_duration")
    private RentDuration rentDuration;

    @Column(name = "start_time")
    private LocalDateTime startTime;

    @Column(name = "end_time")
    private LocalDateTime endTime;

    @Column(name = "total_amount")
    private Double totalAmount;

    @Column(name = "penalty")
    private Double penalty;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Customer getCustomerId() {
        return customerId;
    }

    public void setCustomerId(Customer customerId) {
        this.customerId = customerId;
    }

    public Bike getBikeId() {
        return bikeId;
    }

    public void setBikeId(Bike bikeId) {
        this.bikeId = bikeId;
    }

    public RentDuration getRentDuration() {
        return rentDuration;
    }

    public void setRentDuration(RentDuration rentDuration) {
        this.rentDuration = rentDuration;
    }

    public LocalDateTime getStartTime() {
        return startTime;
    }

    public void setStartTime(LocalDateTime startTime) {
        this.startTime = startTime;
    }

    public LocalDateTime getEndTime() {
        return endTime;
    }

    public void setEndTime(LocalDateTime endTime) {
        this.endTime = endTime;
    }

    public Double getTotalAmount() {
        return totalAmount;
    }

    public void setTotalAmount(Double totalAmount) {
        this.totalAmount = totalAmount;
    }

    public Double getPenalty() {
        return penalty;
    }

    public void setPenalty(Double penalty) {
        this.penalty = penalty;
    }

    @Override
    public String toString() {
        return "Contract{" +
                "id=" + id +
                ", customerId=" + customerId +
                ", bikeId=" + bikeId +
                ", rentDuration=" + rentDuration +
                ", startTime=" + startTime +
                ", endTime=" + endTime +
                ", totalAmount=" + totalAmount +
                ", penalty=" + penalty +
                '}';
    }

    public int getCustomerIDInt() {
        return customerIDInt;
    }

    public void setCustomerIDInt(int customerIDInt) {
        this.customerIDInt = customerIDInt;
    }

    public int getBikeIDInt() {
        return bikeIDInt;
    }

    public void setBikeIDInt(int bikeIDInt) {
        this.bikeIDInt = bikeIDInt;
    }
}
