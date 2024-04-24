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
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur nec finibus turpis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Sed at urna nec nisl ultricies tincidunt sed quis arcu. Donec fermentum et lectus ut tempus. Nunc venenatis tellus ante. Maecenas sed est eget lectus sagittis tempus quis lacinia est. In mattis sollicitudin nunc ac fringilla. Donec volutpat rutrum metus, vitae vestibulum dui egestas nec. Morbi a condimentum sem. Etiam luctus non sapien eget vehicula. In odio augue, ornare fermentum augue quis, pretium dictum ligula. Maecenas lacinia nunc nec quam pharetra vestibulum. Sed nec nunc vitae ligula convallis commodo non quis sem. Mauris blandit, nulla in elementum ultricies, erat dui tristique nisl, suscipit iaculis ligula ligula efficitur nisi. Vestibulum lacus metus, imperdiet eu nunc id, tristique lacinia risus.

                    Duis hendrerit consequat dolor, ac laoreet leo cursus in. Nulla mollis id leo a condimentum. Mauris magna ante, varius eget tortor vitae, feugiat aliquam est. Phasellus gravida elit eget dignissim volutpat. Nulla aliquam blandit vehicula. In hac habitasse platea dictumst. Duis vel dolor a lectus semper tristique. Ut mattis, nisl in faucibus viverra, elit orci rhoncus neque, eget pulvinar nibh turpis at orci. Duis vitae mauris dui. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed in tellus a enim facilisis mollis. Ut ut ipsum ut odio finibus porttitor vel vel lorem.obortis odio eu, hendrerit odio. Maecenas auctor nulla dui. Nulla eu ornare tortor, et suscipit lacus. Nam vestibulum auctor commodo. Cras hendrerit mauris id justo faucibus sagittis. Maecenas sodales vulputate lorem, id elementum quam sollicitudin sit amet. Vivamus sodales quis felis eu sodales. Nam molestie enim sit amet imperdiet fermentum. Sed eget blandit nunc, in laoreet massa. Nullam iaculis aliquet leo a maximus. Aenean eget sollicitudin justo, vel maximus neque. Praesent eget nisi non nibh tempor pulvinar. Integer quis lacinia arcu. Vivamus est diam, luctus id elit quis, dapibus elementum mauris. Nunc mauris turpis, faucibus sed iaculis vel, mattis sodales lorem.</p>
            </section>
            <section className={styles.thirdSection}>
                <h1>Contact</h1>
            </section>
            

            <Footer />
        </main>
    
    
    );
}
export default HomePage;