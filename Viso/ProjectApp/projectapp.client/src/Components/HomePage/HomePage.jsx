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
                <h1>Temat</h1>
            </section>
            <section className={styles.thirdSection}>
                <h1>Kontakt</h1>
            </section>
            

            <Footer />
        </main>
    
    
    );
}
export default HomePage;