package lw1_build2.spring.service;

import lw1_build2.spring.model.Bike;

import java.util.List;

public interface BikeService {
    public void addBike(Bike bike);
    public void updateBike(Bike bike);
    public void removeBike(int id);
    public List<Bike> listBikes();
    public Bike getBikeById(int id);
}
