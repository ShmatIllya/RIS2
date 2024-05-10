package lw1_build2.spring.dao;

import lw1_build2.spring.model.Bike;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.springframework.stereotype.Repository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

@Repository
public class BikeDAOImpl implements BikeDAO{
    private static final Logger logger = LoggerFactory.getLogger(BikeDAOImpl.class);
    private SessionFactory sessionFactory;
    public void setSessionFactory(SessionFactory sf){
        this.sessionFactory = sf;
    }

    @Override
    public void addBike(Bike bike) {
        Session session = this.sessionFactory.getCurrentSession();
        session.persist(bike);
        logger.info("Bike saved successfully, Bike Details=" + bike);
    }

    @Override
    public void updateBike(Bike bike) {
        Session session = this.sessionFactory.getCurrentSession();
        session.merge(bike);
        logger.info("Bike updated successfully, Bike Details=" + bike);
    }

    @Override
    public void removeBike(int id) {
        Session session = this.sessionFactory.getCurrentSession();
        Bike bike = (Bike) session.getReference(Bike.class, id);
        if(null != bike){
            session.remove(bike);
        }
        logger.info("Bike deleted successfully, bike details = " + bike);
    }

    @SuppressWarnings("unchecked")
    @Override
    public List<Bike> listBikes() {
        Session session = this.sessionFactory.getCurrentSession();
        List<Bike> bikesList = session.createQuery("from Bike").list();
        for(Bike bike : bikesList){
            logger.info("Bike List :: " + bike);
        }
        return bikesList;
    }

    @Override
    public Bike getBikeById(int id) {
        Session session = this.sessionFactory.getCurrentSession();
        Bike bike = (Bike) session.getReference(Bike.class, id);
        logger.info("Bike loaded successfully, Bike details=" + bike);
        return bike;
    }
}
