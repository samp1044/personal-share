package at.sampas.personal_share.file.domain;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertThrows;

public class FileNameTest {
    @Test
    public void testFileNameCannotBeEmpty() {
        assertThrows(DomainException.class, () -> new FileName(null));
        assertThrows(DomainException.class, () -> new FileName(""));
        assertThrows(DomainException.class, () -> new FileName(" "));
    }
}
