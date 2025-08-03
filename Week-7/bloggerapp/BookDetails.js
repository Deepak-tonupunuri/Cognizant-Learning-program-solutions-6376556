import React from 'react';

const BookDetails = ({ books }) => {
  return (
    <div className="section">
      <h1>Book Details</h1>
      <ul>
        {books && books.length > 0 ? (
          books.map((book) => (
            <div key={book.id}>
              <h3>{book.bname}</h3>
              <h4>{book.price}</h4>
            </div>
          ))
        ) : (
          <p>No books available</p>
        )}
      </ul>
    </div>
  );
};

export default BookDetails;