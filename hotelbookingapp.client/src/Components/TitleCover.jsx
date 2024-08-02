import React from "react";
import styles from "./TitleCover.module.css";
import PictureCarousel from "./PictureCarousel"; // Adjust the import path as needed

const imageLinks = [
  'https://images.pexels.com/photos/1285625/pexels-photo-1285625.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  'https://images.pexels.com/photos/210186/pexels-photo-210186.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  'https://images.pexels.com/photos/2387418/pexels-photo-2387418.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1',
  // Add more image links as needed
];

export default function TitleCover() {
    return (
      <article className={styles.article}>
        <PictureCarousel links={imageLinks} showControls={false}/>
        <div className={styles.content}>
          <h1 className={styles.header}>Travel your way</h1>
          <h2 className={styles.subheader}>
            Find the best places to travel and explore the world
          </h2>
          <h3 className={`${styles.contentText} pt-5`}>
            With Hootboot
          </h3>
        </div>
      </article>
    );
  }
