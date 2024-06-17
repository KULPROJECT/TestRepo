import * as React from 'react';
import styles from './HomePage.module.scss';
import Header from './Header';
import Footer from './Footer';


function HomePage() {

    return (
        <main>
            <Header />
            <section className={styles.firstSection}>
                <div className={styles.firstSectionDiv}>Order food and more</div>
            </section>
            <section className={styles.secondSection}>
                    <h1>Easy way to add your restaurant</h1>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur nec finibus turpis...</p>
                </section>
            
            <section className={styles.thirdSection}>
                <h1>Contact</h1>
                <div className={styles.avatar}></div>
                <p>email: eattogo@gmail.com <br /> phone +123456789 </p>
            </section>
            <Footer />
        </main>
    );
}

export default HomePage;
